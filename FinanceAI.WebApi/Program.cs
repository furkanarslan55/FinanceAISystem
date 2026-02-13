using FinanceAI.Application;
using FinanceAI.Infrastructure;
using FinanceAI.WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 1. Katman Servisleri (Infrastructure & Application)
// ==========================================
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowUI", policy =>
    {
        policy.WithOrigins("https://localhost:5001", "https://localhost:7096") // UI URL'iniz
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials(); // ⭐ Cookie için gerekli
    });
});
builder.Services.AddHttpClient("CurrencyApi", client =>
{
    client.BaseAddress = new Uri("https://api.exchangerate-api.com/v4/latest/"); // Örnek API URL'si
    client.Timeout = TimeSpan.FromSeconds(30);
});
builder.Services.AddControllers();

// ==========================================
// 2. JWT Authentication Yapılandırması (Eksik Olan Kısım Buydu)
// ==========================================
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]!);

builder.Services.AddAuthentication(options =>
{
    // Burada varsayılan şemayı belirliyoruz
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => // İsmi açıkça belirttik
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        ClockSkew = TimeSpan.Zero
    };
});

// ==========================================
// 3. CORS Yapılandırması
// ==========================================


// ==========================================
// 4. Swagger Yapılandırması
// ==========================================
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinanceAI API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Token değerini girin (Başına Bearer eklemeyin)."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// ==========================================
// 5. Middleware Pipeline (Sıralama Çok Önemli!)
// ==========================================
app.UseCors("AllowUI");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

// CORS her zaman Auth'dan önce gelmeli


// Önce kimlik doğrulama, sonra yetkilendirme
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
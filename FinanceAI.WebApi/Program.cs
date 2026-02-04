using FinanceAI.Application;
using FinanceAI.Infrastructure;
using FinanceAI.WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1. Katman Servislerini Ekle (Infrastructure & Application)
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer(); builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AngularPolicy",
//        policy => policy.WithOrigins("http://localhost:4200") // Angular'ýn adresi
//                        .AllowAnyMethod()
//                        .AllowAnyHeader());
//});

// 2. JWT Authentication Yapýlandýrmasý (Gümrük Kapýsý Ayarlarý)
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});


// 3. Swagger Yapýlandýrmasý (Kilit Ýkonu ve JWT Desteði)
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
        Description = "Token deðerini girin. (Baþýna Bearer eklemenize gerek yoktur, otomatik eklenir)."
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

// 4. HTTP Request Pipeline (Middleware Sýralamasý - ÇOK KRÝTÝK!)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Global Hata Yönetimi
app.UseMiddleware<ExceptionHandlingMiddleware>();
//app.UseCors("AngularPolicy");
app.UseHttpsRedirection();

// SIRALAMA DÝKKAT: Önce Kimlik Doðrula (Sen kimsin?), Sonra Yetkilendir (Girebilir misin?)
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
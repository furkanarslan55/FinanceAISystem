using Microsoft.AspNetCore.Authentication.Cookies;
using UI.DelegatingHandlers;
using UI.Services.AI;
using UI.Services.Auth;
using UI.Services.Dashboard;
using UI.Services.Debt;
using UI.Services.FixedCost;
using UI.Services.Incomes;

var builder = WebApplication.CreateBuilder(args);

// 1. MVC Servisleri
builder.Services.AddControllersWithViews();

// 2. HttpContextAccessor: Cookie okumak ve yazmak için þart
builder.Services.AddHttpContextAccessor();

// 3. AuthService ve TokenHandler Kaydý
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddTransient<TokenHandler>();
builder.Services.AddScoped<IIncomeCategoryService, IncomeCategoryService>();
builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<IDebtCategoryService, DebtCategoryService>();
builder.Services.AddScoped<IDebtService, DebtService>();
builder.Services.AddScoped<IFixedCostCategoryService, FixedCostCategoryService>();
builder.Services.AddScoped<IFixedCostService, FixedCostService>();
builder.Services.AddScoped<IUserSetting, UserSetting>();
builder.Services.AddScoped<IDashboard,Dashboard>();
builder.Services.AddHttpClient<IAiService, AiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7174/"); // Web API adresin
});



// 4. HttpClient Yapýlandýrmasý
// LOGIN ÝÇÝN: TokenHandler içermeyen yalýn bir client (Döngüye girmemek için)
builder.Services.AddHttpClient("AuthClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7174/");
});

// DÝÐER ÝÞLEMLER ÝÇÝN: Her isteðe otomatik token ekleyen client
builder.Services.AddHttpClient("BackendApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7174/");
})
.AddHttpMessageHandler<TokenHandler>();

// 5. Cookie tabanlý Authentication Ayarlarý
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "FinanceAI.Session"; // Çerezin adý
        options.LoginPath = "/Account/Login";     // Yetkisiz giriþte yönlendirilecek sayfa
        options.LogoutPath = "/Account/Logout";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // 1 saatlik oturum
        options.SlidingExpiration = true; // Kullanýcý iþlem yaptýkça süre uzasýn
    });

var app = builder.Build();

// 6. Middleware Pipeline (Sýralama Önemlidir!)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.Use(async (context, next) =>
{
    // Backend adresimizi (7174) ve Google Ads'i ekledik. 
    // Ayrýca localhost:* diyerek tüm localhost portlarýna (Visual Studio araçlarý dahil) izin veriyoruz.
    context.Response.Headers.Append("Content-Security-Policy",
        "connect-src 'self' https://localhost:7174 https://www.googleadservices.com http://localhost:* ws://localhost:*;");
    await next();
});
app.UseStaticFiles();

app.UseRouting();

// Authentication her zaman Authorization'dan ÖNCE gelmeli
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
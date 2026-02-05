using UI.DelegatingHandlers;
using UI.Services.Income;
using UI.Services.Login;

var builder = WebApplication.CreateBuilder(args);

// ==========================
// 1. MVC & VIEW YAPILANDIRMASI
// ==========================
builder.Services.AddControllersWithViews();

// ==========================
// 2. DEPENDENCY INJECTION (DI) - SERVİS KAYITLARI
// ==========================
// Scoped: Her HTTP isteğinde yeni bir nesne oluşturulur.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<IIncomeCategoryService, IncomeCategoryService>();

// JwtHandler ve Session erişimi için kritik servis
builder.Services.AddHttpContextAccessor();

// ==========================
// 3. SESSION YAPILANDIRMASI
// ==========================
builder.Services.AddDistributedMemoryCache(); // Session verilerini RAM'de tutar
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // 30 dk işlem yapılmazsa session düşer
    options.Cookie.HttpOnly = true; // Tarayıcı tarafındaki JS'lerin cookie'ye erişmesini engeller (Güvenlik)
    options.Cookie.IsEssential = true; // GDPR/KVKK kuralları için zorunlu işaretleme
});

// ==========================
// 4. HTTP CLIENT & JWT HANDLER (MİMARİNİN KALBİ)
// ==========================
// DelegatingHandler'ı DI konteynırına kaydediyoruz.
builder.Services.AddTransient<JwtHandler>();

// "ApiClient" isminde merkezi bir HttpClient yapılandırıyoruz.
builder.Services.AddHttpClient("ApiClient", client =>
{
    // appsettings.json dosyasından BaseUrl'i okuyoruz. 
    // Yoksa hata almamak için bir default değer veya kontrol eklemek iyi olur.
    var baseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7174/api/";
    client.BaseAddress = new Uri(baseUrl);
})
.AddHttpMessageHandler<JwtHandler>(); // Bu client üzerinden giden her isteğe otomatik Token eklenir.

var app = builder.Build();

// ==========================
// 5. MIDDLEWARE PIPELINE (SIRALAMA KRİTİKTİR)
// ==========================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // Rotalama sistemini başlatır

// 🔥 DİKKAT: UseSession, UseRouting'den SONRA, Authentication'dan ÖNCE gelmelidir.
app.UseSession();

app.UseAuthentication(); // Kim olduğun?
app.UseAuthorization();  // Yetkin ne?

// ==========================
// 6. ROTA YAPILANDIRMASI
// ==========================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
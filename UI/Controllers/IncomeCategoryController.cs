using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UI.Models.ViewModel.Income;
using UI.Services.Income;

namespace UI.Controllers
{
    public class IncomeCategoryController : Controller
    {
        private readonly IIncomeCategoryService _incomeCategoryService;

        // Constructor Injection: .NET, Program.cs'de kaydettiğimiz servisi buraya otomatik getirir.
        public IncomeCategoryController(IIncomeCategoryService incomeCategoryService)
        {
            _incomeCategoryService = incomeCategoryService;
        }

        // 1. Listeleme (Index) Sayfası
        // Kullanıcı tarayıcıya "/IncomeCategory/Index" yazdığında burası çalışır.
        public async Task<IActionResult> Index()
        {
            // Servis üzerinden API'ye gidip verileri alıyoruz.
            var categories = await _incomeCategoryService.GetAllAsync();

            // Aldığımız listeyi View'a (HTML tarafına) gönderiyoruz.
            return View(categories);
        }

        // 2. Yeni Kategori Ekleme Sayfası (Sadece Sayfayı Gösterir)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 3. Yeni Kategori Ekleme İşlemi (Formdan Gelen Veriyi API'ye Gönderir)
        [HttpPost]
        public async Task<IActionResult> Create(IncomeCategoryCreateDto model)
        {
            if (ModelState.IsValid)
            {
                await _incomeCategoryService.CreateAsync(model);
                // İşlem başarılıysa liste sayfasına geri dön.
                return RedirectToAction(nameof(Index));
            }
            // Hata varsa aynı sayfada kal ve modeli geri gönder (hataları göstermek için).
            return View(model);
        }
    }
}

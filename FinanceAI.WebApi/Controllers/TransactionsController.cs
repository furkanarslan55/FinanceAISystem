using FinanceAI.Application.Dtos.Transaction;
using FinanceAI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransactionCreateDto transactionCreateDto)
        {
            // İşlem oluşturulurken servis içindeki borç düşme mantığı da çalışacak.
            await _transactionService.CreateTransactionAsync(transactionCreateDto);

            return Ok(new { message = "İşlem başarıyla kaydedildi ve ilgili güncellemeler yapıldı." });
        }
    }
}

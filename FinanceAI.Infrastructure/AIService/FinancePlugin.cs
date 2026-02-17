using FinanceAI.Core.Entities;
using FinanceAI.Core.Entities.DebtEntity;
using FinanceAI.Core.Entities.FixedCostEntity;
using FinanceAI.Infrastructure.Features.Incomes;
using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure.AIService
{
    public class FinancePlugin
    {
        private readonly IIncomeRepository _incomeRepo;
        private readonly IFixedCostRepository _fixedCostRepository;
        private readonly IDebtRepository _debtRepository;

        // Constructor ile repository'ni içeri alıyorsun (Clean Architecture gereği)
        public FinancePlugin(IDebtRepository debtRepository,IIncomeRepository ıncomeRepository,IFixedCostRepository fixedCostRepository)
        {
            _debtRepository = debtRepository;
            _incomeRepo = ıncomeRepository;
            _fixedCostRepository = fixedCostRepository;
        }

        [KernelFunction] // Bu metodu AI'nın görebileceğini belirtir
        [Description("Kullanıcının mevcut tüm borçlarını, miktarlarını ve vadelerini getirir.")]
        public async Task<string> GetDebts()
        {
            var debts = await _debtRepository.GetAllAsync();

            if (!debts.Any()) return "Şu an kayıtlı bir borç bulunmamaktadır.";

            // AI'nın en iyi anlayacağı format düz metindir
            var summary = debts.Select(d => $"- {d.Name}: {d.Amount} TL, Son Ödeme: {d.DueDate.ToShortDateString()}");
            return string.Join("\n", summary);
        }
        [KernelFunction]
        [Description("Kullanıcının toplam borç miktarını hesaplar.")]
        public async Task<string> GetTotalDebt()
        {
            var debts = await _debtRepository.GetAllAsync();
            var total = debts.Sum(d => d.Amount);
            return $"Toplam borç miktarınız: {total} TL";
        }
        [KernelFunction]
        [Description("Kullanıcının aylık düzenli gelirlerini ve maaş bilgilerini getirir.")]
        public async Task<string> GetIncomes()
        {
            var incomes = await _incomeRepo.GetAllAsync();
            if (!incomes.Any()) return "Henüz eklenmiş bir gelir bulunmuyor.";

            return string.Join("\n", incomes.Select(i => $"- {i.Description}: {i.Amount} TL ({i.IncomeCategory})"));
        }

        [KernelFunction]
        [Description("Kullanıcının kira, fatura, abonelik gibi her ay ödediği sabit giderleri getirir.")]
        public async Task<string> GetFixedCosts()
        {
            var costs = await _fixedCostRepository.GetAllAsync();
            if (!costs.Any()) return "Kayıtlı sabit gider bulunamadı.";

            return string.Join("\n", costs.Select(c => $"- {c.Name}: {c.Amount} TL (Kategorisi: {c.FixedCostCategory})"));
        }
    }
}

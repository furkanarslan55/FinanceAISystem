using FinanceAI.Application.Dtos.Debt;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Validations
{
    public class DebtCreateValidator : AbstractValidator<DebtCreateDto>
    {
        public DebtCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Borç başlığı boş olamaz.");
            RuleFor(x => x.TotalAmount).GreaterThan(0).WithMessage("Toplam borç 0'dan büyük olmalıdır.");
            RuleFor(x => x.RemainingAmount).LessThanOrEqualTo(x => x.TotalAmount)
                .WithMessage("Kalan borç toplam borçtan fazla olamaz.");
            RuleFor(x => x.InterestRate).InclusiveBetween(0, 100).WithMessage("Faiz oranı 0-100 arasında olmalıdır.");
        }
    }
}

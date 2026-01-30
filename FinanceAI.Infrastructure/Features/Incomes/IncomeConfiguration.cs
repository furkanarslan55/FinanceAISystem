using FinanceAI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FinanceAI.Infrastructure.Features.Incomes
{
    public class IncomeConfiguration :IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            // İlişki: IncomeCategory ile bire çok ilişki
            builder.HasOne(i => i.IncomeCategory)
                   .WithMany(ic => ic.Incomes)
                   .HasForeignKey(i => i.IncomeCategoryId)
                   .OnDelete(DeleteBehavior.Restrict); // Silme davranışı
            // İlişki: AppUser ile bire çok ilişki
            builder.HasOne(i => i.AppUser)
                   .WithMany(au => au.Incomes)
                   .HasForeignKey(i => i.AppUserId)
                   .OnDelete(DeleteBehavior.Cascade); // Silme davranışı
        }

    }
}

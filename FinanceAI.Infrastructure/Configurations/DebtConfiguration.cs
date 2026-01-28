using FinanceAI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure.Configurations
{
    public class DebtConfiguration : IEntityTypeConfiguration<Debt>
    {
        public void Configure(EntityTypeBuilder<Debt> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.TotalAmount).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.RemainingAmount).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();

            // İlişki Tanımı: Bir Borcun bir kullanıcısı olur.
            builder.HasOne(x => x.AppUser)
                   .WithMany(x => x.Debts)
                   .HasForeignKey(x => x.AppUserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

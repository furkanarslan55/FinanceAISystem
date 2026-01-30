using FinanceAI.Core.Entities.DebtEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceAI.Infrastructure.Features.Debts
{
    public class DebtConfiguration : IEntityTypeConfiguration<Debt>
    {


        public void Configure(EntityTypeBuilder<Debt> builder)
        {
            builder.ToTable("Debts");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            
            builder.Property(d => d.DueDate)
                .IsRequired();

            builder.HasOne(d => d.DebtCategory)
                .WithMany(dc => dc.Debts)
                .HasForeignKey(d => d.DebtCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.AppUser)
                .WithMany(u => u.Debts)
                .HasForeignKey(d => d.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}

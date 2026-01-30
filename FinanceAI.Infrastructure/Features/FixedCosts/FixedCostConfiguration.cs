using FinanceAI.Core.Entities.FixedCostEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure.Features.FixedCosts
{
    public class FixedCostConfiguration : IEntityTypeConfiguration<FixedCost>
    {
        public void Configure(EntityTypeBuilder<FixedCost> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(x => x.AppUser)
                 .WithMany(u => u.FixedCosts)
                 .HasForeignKey(x => x.AppUserId)
                 .OnDelete(DeleteBehavior.NoAction); // 🔴 önemli
        }
    }
}
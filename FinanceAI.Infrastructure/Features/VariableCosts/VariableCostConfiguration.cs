using FinanceAI.Core.Entities.VariableCostEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure.Features.VariableCosts
{
    public class VariableCostConfiguration :IEntityTypeConfiguration<VariablesCosts>
    {

        public void Configure(EntityTypeBuilder<VariablesCosts> builder)
        {
            builder.HasKey(vc => vc.Id);
            builder.Property(vc => vc.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(vc => vc.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
           
            builder.HasIndex(vc => vc.Name);
            builder.HasOne(vc => vc.VariableCostCategory)
                .WithMany(vcc => vcc.VariableCosts)
                .HasForeignKey(vc => vc.VariableCostCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(vc => vc.AppUser)
                .WithMany(au => au.VariablesCosts)
                .HasForeignKey(vc => vc.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }



    }
}

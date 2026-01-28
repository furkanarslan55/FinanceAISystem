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
    public class DebtCategoryConfiguration : IEntityTypeConfiguration<DebtCategory>
    {
        public void Configure(EntityTypeBuilder<DebtCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            // Seed Data: Uygulama ilk kalktığında varsayılan kategorileri ekleyelim
            builder.HasData(
                new DebtCategory { Id = 1, Name = "Banka Kredisi" },
                new DebtCategory { Id = 2, Name = "Kredi Kartı" },
                new DebtCategory { Id = 3, Name = "Eğitim" },
                new DebtCategory { Id = 4, Name = "Borç (Bireysel)" },
                new DebtCategory { Id = 5, Name = "Diğer" }
            );
        }
    }
}

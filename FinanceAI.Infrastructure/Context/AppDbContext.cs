using FinanceAI.Core.Entities;
using FinanceAI.Core.Entities.AppUserEntity;
using FinanceAI.Core.Entities.DebtEntity;
using FinanceAI.Core.Entities.FixedCostEntity;
using FinanceAI.Core.Entities.Incomes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure.Context
{
    public class AppDbContext :DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<AppUser> Users { get; set; }


        public DbSet<Debt> Debts { get; set; }
        public DbSet<DebtCategory> DebtCategories { get; set; }


        public DbSet<FixedCost> FixedCosts { get; set; }
        public DbSet<FixedCostCategory> FixedCostCategories { get; set; }


        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tüm Configuration dosyalarını (varsa) otomatik olarak uygular
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

         

            base.OnModelCreating(modelBuilder);
        }

    }
}

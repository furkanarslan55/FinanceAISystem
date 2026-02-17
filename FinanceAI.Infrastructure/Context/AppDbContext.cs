using FinanceAI.Application.Features.Dashboard;
using FinanceAI.Application.Interfaces;
using FinanceAI.Core.Entities;
using FinanceAI.Core.Entities.AppUserEntity;
using FinanceAI.Core.Entities.DebtEntity;
using FinanceAI.Core.Entities.FixedCostEntity;
using FinanceAI.Core.Entities.Incomes;
using FinanceAI.Core.Entities.VariableCostEntity;
using FinanceAI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinanceAI.Infrastructure.Context
{
    public class AppDbContext :DbContext
    {
        

        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
          

        }
        

        public DbSet<AppUser> Users { get; set; }


        public DbSet<Debt> Debts { get; set; }
        public DbSet<DebtCategory> DebtCategories { get; set; }


        public DbSet<FixedCost> FixedCosts { get; set; }
        public DbSet<FixedCostCategory> FixedCostCategories { get; set; }

        public DbSet<VariablesCosts> VariableCosts { get; set; }
        public DbSet<VariableCostCategory> VariableCostCategories { get; set; }

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

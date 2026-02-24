using FinanceAI.Application.Interfaces;
using FinanceAI.Core.Entities.DebtEntity;
using FinanceAI.Core.Entities.FixedCostEntity;
using FinanceAI.Core.Entities.FixedCostsEntity;
using FinanceAI.Core.Entities.Incomes;
using FinanceAI.Core.Entities.VariableCostEntity;
using FinanceAI.Core.GenericInterfaces;
using FinanceAI.Core.Interfaces;
using FinanceAI.Infrastructure.Context;
using FinanceAI.Infrastructure.Features.Debts;
using FinanceAI.Infrastructure.Features.FixedCosts;
using FinanceAI.Infrastructure.Features.Incomes;
using FinanceAI.Infrastructure.Features.VariableCosts;
using FinanceAI.Infrastructure.GenericRepositories;
using FinanceAI.Infrastructure.Repositories;
using FinanceAI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceAI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext Kaydı
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

            // Repository ve UnitOfWork Kayıtları
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
           services.AddHttpContextAccessor();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IIncomeRepository, IncomeRepository>();
            services.AddScoped<IIncomeCategoryRepository, IncomeCategoryRepository>();
            services.AddScoped<IFixedCostRepository, FixedCostRepository>();
            services.AddScoped<IFixedCostCategoryRepository, FixedCostCategoryRepository>();
            services.AddScoped<IVariableCostRepository, VariableCostRepository>();
            services.AddScoped<IVariableCostCategoryRepository, VariableCostCategoryRepository>();
            services.AddScoped<ICurrencyExchange, CurrencyExchange>();

            services.AddScoped<IDebtCategoryRepository, DebtCategoryRepository>();
            services.AddScoped<IDebtRepository, DebtRepository>();
       
            services.AddScoped(typeof(IAppLogger), typeof(AppLogger<>));
            services.AddHttpContextAccessor();
          
 

            
        }
    }
}

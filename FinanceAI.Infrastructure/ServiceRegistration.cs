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
using FinanceAI.Infrastructure.Repositories;
using FinanceAI.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            services.AddHttpContextAccessor();
          
        //    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //.AddJwtBearer(options =>
        //{
        //    options.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidateLifetime = true,
        //        ValidateIssuerSigningKey = true,
        //        ValidIssuer = configuration["Jwt:Issuer"],
        //        ValidAudience = configuration["Jwt:Audience"],
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
        //    };
        //});

            
        }
    }
}

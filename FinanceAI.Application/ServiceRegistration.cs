using FinanceAI.Application.Features.Debts;
using FinanceAI.Application.Features.FixedCost;
using FinanceAI.Application.Features.Incomes;
using FinanceAI.Application.Features.VariableCost.VariableCostService;
using FinanceAI.Application.Features.VariableCosts.VariableCostCategoryService;
using FinanceAI.Application.Interfaces;
using FinanceAI.Application.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace FinanceAI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
          services.AddScoped<IIncomeService, IncomeService>();
            services.AddScoped<IIncomeCategoryService, IncomeCategoryService>();
            //services.AddScoped<IFixedCostService, FixedCostService>();
            services.AddScoped<IFixedCostCategoryService, FixedCostCategoryService>();
            services.AddScoped<IDebtCategoryServices, DebtCategoryServices>();
           services.AddScoped<IDebtServices, DebtServices>();
            services.AddScoped<IVariableCostService, VariableCostService>();
            services.AddScoped<IVariableCostCategoryService, VariableCostCategoryService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
        }
    }
}

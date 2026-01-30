using FinanceAI.Application.Features.Incomes;
using FinanceAI.Application.Interfaces;
using FinanceAI.Application.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper;
using FinanceAI.Application.Features.FixedCost;


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



            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
        }
    }
}

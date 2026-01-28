using FinanceAI.Application.Interfaces;
using FinanceAI.Application.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace FinanceAI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDebtService, DebtService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IDebtCategoryService, DebtCategoryService>();
            services.AddFluentValidationAutoValidation();
        }
    }
}

using FinanceAI.Application.Interfaces;
using FinanceAI.Application.Services;
using FinanceAI.Core.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FinanceAI.Application.Features.Incomes;
namespace FinanceAI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
          services.AddScoped<IIncomeService, IncomeService>();


            services.AddFluentValidationAutoValidation();
        }
    }
}

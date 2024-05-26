using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(x => x.RegisterServicesFromAssembly(executingAssembly));
            services.AddValidatorsFromAssembly(executingAssembly);
            services.AddFluentValidationAutoValidation();

            return services;
        }
    }
}

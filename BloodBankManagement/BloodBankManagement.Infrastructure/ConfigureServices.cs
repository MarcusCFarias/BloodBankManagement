using BloodBankManagement.Application.Features.Common.Interfaces;
using BloodBankManagement.Application.Features.Events;
using BloodBankManagement.Domain.Events;
using BloodBankManagement.Domain.Repositories;
using BloodBankManagement.Infrastructure.Persistence;
using BloodBankManagement.Infrastructure.Persistence.Repositories;
using BloodBankManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManagement.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataBaseContext(configuration);
            services.AddRepositories();
            services.AddExternalServices();

            return services;
        }
        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBloodStorageRepository, BloodStorageRepository>();
            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
        }
        private static void AddDataBaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                //var host = Environment.GetEnvironmentVariable("DB_HOST");
                //var name = Environment.GetEnvironmentVariable("DB_NAME");
                //var user = Environment.GetEnvironmentVariable("DB_USER");
                //var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                //var connectionString = $"Server={host};Database={name};User Id={user};Password={password};Trusted_Connection=True;MultipleActiveResultSets=true";

                options.UseSqlServer(connectionString);
            });
        }

        private static void AddExternalServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IAddressService, AddressService>();
        }

       
    }
}

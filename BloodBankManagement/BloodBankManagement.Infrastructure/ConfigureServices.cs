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
using Microsoft.Extensions.Logging;
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
                var database = Environment.GetEnvironmentVariable("MSSQL_DATABASE");
                var user = Environment.GetEnvironmentVariable("MSSQL_USER");
                var password = Environment.GetEnvironmentVariable("MSSQL_SA_PASSWORD");

                var connectionString = $"Server=db;Database={database};User Id={user};Password={password};TrustServerCertificate=true;MultipleActiveResultSets=true;";

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

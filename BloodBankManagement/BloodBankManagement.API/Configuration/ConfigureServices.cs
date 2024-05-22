using BloodBankManagement.Infrastructure;

namespace BloodBankManagement.API.Configuration
{
    internal static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructure(configuration);

            return services;
        }
    }
}

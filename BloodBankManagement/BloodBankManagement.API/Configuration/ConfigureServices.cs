using BloodBankManagement.API.Middlewares;
using BloodBankManagement.Application;
using BloodBankManagement.Infrastructure;

namespace BloodBankManagement.API.Configuration
{
    internal static class ConfigureServices
    {
        public static IServiceCollection AddAllServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureLayer(configuration);
            services.AddApplicationLayer();

            services.AddControllers();
            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddExceptionHandler<GlobalExpectionHandler>();

            return services;
        }
    }
}

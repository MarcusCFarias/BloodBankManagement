
using BloodBankManagement.API.Configuration;

namespace BloodBankManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Configuration.AddEnvironmentVariables();

            builder.Services.AddAllServices(builder.Configuration);

            var app = builder.Build();
            app.ConfigureAllApp(builder.Services);

            app.Run();
        }
    }
}

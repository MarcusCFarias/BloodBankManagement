using System.Runtime.CompilerServices;

namespace BloodBankManagement.API.Configuration
{
    internal static class ConfigureApp
    {
        public static void ConfigureAllApp(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}

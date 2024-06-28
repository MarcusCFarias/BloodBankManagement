using BloodBankManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BloodBankManagement.API.Configuration
{
    internal static class ConfigureApp
    {
        public static void ConfigureAllApp(this WebApplication app)
        {
            //Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.ApplyMigration();

            app.UseHttpsRedirection();

            app.UseExceptionHandler(options => { });

            app.UseAuthorization();

            app.MapControllers();
        }

        private static void ApplyMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                dbContext.Database.Migrate();
            }
        }
    }
}

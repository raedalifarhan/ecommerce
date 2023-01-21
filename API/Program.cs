
using API.ProjectStartup;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    [Obsolete]
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args)
                     .RegisterServices();

        var app = builder.Build()
                .SetupMiddleware();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                await context.Database.MigrateAsync();
                await ApplicationContextSeed.SeedAsync(context, loggerFactory);
            }
            catch (System.Exception ex)
            {

                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error accured during migration");
            }
        }

        app.Run();
    }
}
using Confab.Shared.Abstraction;
using Confab.Shared.Infrastructure.Api;
using Confab.Shared.Infrastructure.Exceptions;
using Confab.Shared.Infrastructure.Postgres;
using Confab.Shared.Infrastructure.Services;
using Confab.Shared.Infrastructure.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Confab.Bootstrapper")]
namespace Confab.Shared.Infrastructure;
internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddErrorHandling();
        services.AddPostgres();
        services.AddSingleton<IClock, UtcClock>();
        services.AddHostedService<AppInitializer>();
        services
            .AddControllers()
            //zapewnia ladowanie controllerow jako internal 
            .ConfigureApplicationPartManager(manager =>
            {
                manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
            });

        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseErrorHandling();
        app.UseRouting();
        return app;
    }

    public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        return configuration.GetOptions<T>(sectionName);
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
    {
        var options = new T();
        configuration.GetSection(sectionName).Bind(options);
        return options;
    }
}

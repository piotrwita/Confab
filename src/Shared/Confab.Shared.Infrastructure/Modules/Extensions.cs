using Confab.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Confab.Shared.Infrastructure.Modules;

internal static class Extensions
{
    internal static IServiceCollection AddModuleInfo(this IServiceCollection services, IList<IModule> modules)
    {
        var moduleInforProfider = new ModuleInfoProvider();
        var moduleInfo =
            modules?.Select(x => new ModuleInfo(x.Name, x.Path, x.Policies ?? Enumerable.Empty<string>())) ??
            Enumerable.Empty<ModuleInfo>();
        moduleInforProfider.Modules.AddRange(moduleInfo);
        services.AddSingleton(moduleInforProfider);
        return services;
    }

    internal static void MapModuleInfo(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapGet("modules", context =>
        {
            var moduleInfoProvider = context.RequestServices.GetRequiredService<ModuleInfoProvider>();
            return context.Response.WriteAsJsonAsync(moduleInfoProvider.Modules);
        });
    }

    //zaladowanie konfiguracji dla danego modulu
    internal static IHostBuilder ConfigureModules(this IHostBuilder builder)
    => builder.ConfigureAppConfiguration((ctx, cfg) =>
    {
        //zlap cokolwiek
        foreach (var settings in GetSettings("*"))
        {
            cfg.AddJsonFile(settings);
        }

        //nadpisanie modulu ustawieniam
        foreach (var settings in GetSettings($"*.{ctx.HostingEnvironment.EnvironmentName}"))
        {
            cfg.AddJsonFile(settings);
        }

        IEnumerable<string> GetSettings(string pattern)
        => Directory.EnumerateFiles(
            ctx.HostingEnvironment.ContentRootPath, $"module.{pattern}.json", SearchOption.AllDirectories);
    });
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Confab.Shared.Infrastructure.Modules;

internal static class Extensions
{
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

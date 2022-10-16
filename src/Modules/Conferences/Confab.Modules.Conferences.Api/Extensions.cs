using Confab.Modules.Conferences.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Confab.Bootstrapper")]
namespace Confab.Modules.Conferences.Api;
internal static class Extensions
{
    public static IServiceCollection AddConferences(this IServiceCollection services)
    {
        services.AddCore();
        return services;
    }
}

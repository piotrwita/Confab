using Confab.Modules.Conferences.Core.Policies;
using Confab.Modules.Conferences.Core.Repositories;
using Confab.Modules.Conferences.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Confab.Modules.Conferences.Api")]
namespace Confab.Modules.Conferences.Core;
internal static class Extensions
{ 
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddSingleton<IHostRepository, InMemoryHostRepository>();
        //jakby do klasy bylo wstrzykiwane repo to by musialo byc scoped
        services.AddSingleton<IHostDeletionPolicy, HostDeletionPolicy>();
        services.AddSingleton<IConferenceDeletionPolicy, ConferenceDeletionPolicy>();
        services.AddScoped<IHostService, HostService>();
        services.AddSingleton<IConferenceRepository, InMemoryConferenceRepository>();  
        services.AddScoped<IConferenceService, ConferenceService>();
        return services;
    }
}

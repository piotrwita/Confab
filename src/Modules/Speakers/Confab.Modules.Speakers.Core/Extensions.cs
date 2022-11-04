using Confab.Modules.Speakers.Core.DAL;
using Confab.Modules.Speakers.Core.DAL.Repositories;
using Confab.Modules.Speakers.Core.Repositories;
using Confab.Modules.Speakers.Core.Services;
using Confab.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Confab.Modules.Speakers.Api")]
namespace Confab.Modules.Speakers.Core;
internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        //services.AddPostgres<SpeakersDbContext>();
        services.AddSingleton<ISpeakerRepository, InMemorySpeakerRepository>();
        services.AddScoped<ISpeakerService, SpeakerService>();
        return services;
    }
}

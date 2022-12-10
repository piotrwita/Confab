using Confab.Modules.Agendas.Domain.Agendas.Repositories;
using Confab.Modules.Agendas.Domain.CallForPapers.Repositories;
using Confab.Modules.Agendas.Domain.Submissions.Repositories;
using Confab.Modules.Agendas.Infrastructure.EF;
using Confab.Modules.Agendas.Infrastructure.EF.Repositories;
using Confab.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;

namespace Confab.Modules.Agendas.Infrastructure;
public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        => services
            .AddPostgres<AgendasDbContext>()
            .AddScoped<IAgendaTracksRepository, AgendaTracksRepository>()
            .AddScoped<IAgendaItemsRepository, AgendaItemsRepository>()
            .AddScoped<ISpeakerRepository, SpeakerRepository>()
            .AddScoped<ISubmissionRepository, SubmissionRepository>()
            .AddScoped<ICallForPapersRepository, CallForPapersRepository>();
}

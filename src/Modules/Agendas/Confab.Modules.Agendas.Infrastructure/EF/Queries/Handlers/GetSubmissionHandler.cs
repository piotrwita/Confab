using Confab.Modules.Agendas.Application.Submissions.DTO;
using Confab.Modules.Agendas.Application.Submissions.Queries;
using Confab.Modules.Agendas.Domain.Submissions.Entities;
using Confab.Modules.Agendas.Infrastructure.EF.Mappings;
using Confab.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Agendas.Infrastructure.EF.Queries.Handlers;

internal sealed class GetSubmissionHandler : IQueryHandler<GetSubmission, SubmissionDto>
{
    private readonly DbSet<Submission> _submissions;

    public GetSubmissionHandler(AgendasDbContext context)
    {
        _submissions = context.Submissions;
    }

    public Task<SubmissionDto> HandleAsync(GetSubmission query)
        => _submissions
            //nie chcemy aby ef sledzil zmiany w naszym submission - tu tylko mamy odczyt danych (nie obieramy ich zeby wykonac jakis update)
            .AsNoTracking()
            .Where(x => x.Id.Equals(query.Id))
            .Include(x => x.Speakers)
            //tu mozna uzyc automapera
            .Select(s => s.AsDto())
            .SingleOrDefaultAsync();
}

using Confab.Modules.Agendas.Domain.CallForPapers.Entities;
using Confab.Modules.Agendas.Domain.Submissions.Entities;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Agendas.Infrastructure.EF;

internal sealed class AgendasDbContext : DbContext
{
    public DbSet<Submission> Submissions { get; set; }
    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<CallForPapers> CallForPapers { get; set; }

    public AgendasDbContext(DbContextOptions<AgendasDbContext> options) : base(options)
    {
    }

    //zmieniamy nasz domyslny schemat i aplikujemy konfiguracje
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("agendas");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}

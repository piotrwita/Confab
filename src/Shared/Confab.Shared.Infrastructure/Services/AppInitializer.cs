using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confab.Shared.Infrastructure.Services;

internal class AppInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<AppInitializer> _logger;

    public AppInitializer(IServiceProvider serviceProvider, ILogger<AppInitializer> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        //wyszukuje wszystkie dbcontext zdefiniowane w solucji
        var dbContextTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            //wszystkie ktore dziedzicza po dbcontext i ktore nie sa oryginalnym dbcontext
            .Where(x => typeof(DbContext).IsAssignableFrom(x) && !x.IsInterface && x != typeof(DbContext));

        using var scope = _serviceProvider.CreateScope();

        foreach(var dbContextType in dbContextTypes)
        {
            var dbContext = scope.ServiceProvider.GetRequiredService(dbContextType) as DbContext;
            dbContext.Database.MigrateAsync(cancellationToken);
        }


    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}

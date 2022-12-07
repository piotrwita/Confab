using Confab.Shared.Abstractions.Kernel;
using Microsoft.Extensions.DependencyInjection;

namespace Confab.Shared.Infrastructure.Kernel;

internal sealed class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task DispatchAsync(params IDomainEvent[] events)
    {
        if (events is null || !events.Any())
        {
            return;
        }

        using var scope = _serviceProvider.CreateScope();

        foreach(var @event in events)
        {
            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(@event.GetType());
            //nie robimy GetRequiredService poniewaz tak jak w przypadku zdarzen domenowych mozemy miec od 0 do n reciver'ow
               //czyli moze byc przypadek w ktorym nikt nie zadeklarowal zdarzenia dla naszego zdarzenia domenowego
            var handlers = scope.ServiceProvider.GetServices(handlerType);

            var tasks = handlers
                .Select(x => (Task)handlerType
                    .GetMethod(nameof(IDomainEventHandler<IDomainEvent>.HandleAsync))
                    .Invoke(x, new[] { @event }));

            await Task.WhenAll(tasks);
        }
    }
}
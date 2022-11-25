using Confab.Shared.Abstractions.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Confab.Shared.Infrastructure.Events;


internal static class Extensions
{
    //paczka scrutor umozliwia dwie rzeczy
    //mozliwosc tworzenia integracji wzorca dekoratora z kontenerem ioc
    //tutaj wykorzystujemy aktualnie - skanowanie assembly w poszukiwaniu konkretnych typow i automatycznej ich rejestracji w kontenerze
    public static IServiceCollection AddEvents(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        services.AddSingleton<IEventDispatcher, EventDispatcher>();

        //ze wszystkich naszych assemblies znajdz wszystkie klasy ktore implementuja ieventhandler
        //zarejestruj je pod kluczem ieventhandler
        //z cyklem zycia scoped
        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    } 
}



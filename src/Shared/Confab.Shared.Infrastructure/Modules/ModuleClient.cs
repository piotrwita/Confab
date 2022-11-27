using Confab.Shared.Abstractions.Modules;

namespace Confab.Shared.Infrastructure.Modules;

internal sealed class ModuleClient : IModuleClient
{
    private readonly IModuleRegistry _moduleRegistry;
    private readonly IModuleSerializer _moduleSerializer;

    public ModuleClient(IModuleRegistry moduleRegistry, IModuleSerializer moduleSerializer)
    {
        _moduleRegistry = moduleRegistry;
        _moduleSerializer = moduleSerializer;
    }

    public async Task PublishAsync(object message)
    {
        //wyciagniecie klucza
        var key = message.GetType().Name;

        //pobranie rejestracji w ramach rejestru
        var registrations = _moduleRegistry.GetBroadcastRegistrations(key);

        var tasks = new List<Task>();

        //wywolanie zarejestrowanych funcow - akcji przypisanych
        foreach(var registration in registrations)
        {
            var action = registration.Action;
            var receiverMessage = TranslateType(message, registration.ReceiverType);
            tasks.Add(action(receiverMessage));
        }

        await Task.WhenAll(tasks);
    }

    //dwa etapy
    //1 typ ktory dostajemy czyli nasz message ktory opublikujemy
    //np nasz conferencecreated po stronie modulu konferencji zostanie zserioalizowany do postaci byte array
    //2 nastepnie bedziemy deserializowali go na typ z modulu tickets
    //dzieki temu przy wywolaniu naszego handlera nie bedziemy mieli mismatcha na poziomie typu ktory domyslnie ma ustawione inne namespace (jest innym obiektem)
    private object TranslateType(object value, Type type)
        => _moduleSerializer.Deserialize(_moduleSerializer.Serialize(value), type);
}
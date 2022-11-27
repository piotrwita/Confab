namespace Confab.Shared.Infrastructure.Modules;

public sealed class ModuleBroadcastRegistration
{
    //jakiego typu wiadomosci sie spodiewamy (na to castujemy)
    public Type ReceiverType { get; }
    public Func<object, Task> Action { get; }
    public string Key => ReceiverType.Name;

    public ModuleBroadcastRegistration(Type receiverType, Func<object, Task> action)
    {
        ReceiverType = receiverType;
        Action = action;
    }
}
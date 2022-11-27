namespace Confab.Shared.Infrastructure.Modules;

internal interface IModuleRegistry
{
    IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistrations(string key);

    //type - jakiego typu oczekujemy w momencie wywoalnia tej naszej operacji (potrzebne pozniej do castowania)
    //akcaja - func ktory przyjmuje jakis obiekt i zwraca taska

    void AddBroadcastAction(Type requestType, Func<object, Task> action);
}

namespace Confab.Shared.Infrastructure.Modules;

internal interface IModuleRegistry
{
    IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistrations(string key);
    ModuleRequestRegistration GetRequestRegistration(string path);

    //type - jakiego typu oczekujemy w momencie wywoalnia tej naszej operacji (potrzebne pozniej do castowania)
    //akcaja - func ktory przyjmuje jakis obiekt i zwraca taska

    void AddBroadcastAction(Type requestType, Func<object, Task> action);

    void AddRequestAction(string path, Type requestType, Type responseType, Func<object, Task<object>> action);
}

namespace Confab.Shared.Infrastructure.Modules;

internal interface IModuleRegistry
{
    IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistrations(string key);
    //nie ma listy bo jest jeden unikalny odbiorca danej sciezki
    //nie moze byc jednej takiej samej sciezki na ktora nasluchuja rozne kontrolery
    ModuleRequestRegistration GetRequestRegistration(string path);

    //type - jakiego typu oczekujemy w momencie wywoalnia tej naszej operacji (potrzebne pozniej do castowania)
    //akcaja - func ktory przyjmuje jakis obiekt i zwraca taska

    void AddBroadcastAction(Type requestType, Func<object, Task> action);


    //type - sciezka http (cos na zasanie endpoi
    //request type - objekt jaki wysylamy , typ zadania
    //responsetype - zwrotka typ jaki oczekujemy po zwrotce z serwera naszego modulu
    //funk - akcja , obiekt wchodzacy jako request
    void AddRequestAction(string path, Type requestType, Type responseType, Func<object, Task<object>> action);
}

using Confab.Shared.Abstractions.Messaging;

namespace Confab.Shared.Abstractions.Queries;

//Marker 
public interface IQuery 
{
}

//rezultat - dane ktorych oczekujemy w ramach przetwarzania kwerendy
public interface IQuery<T> : IQuery
{
}

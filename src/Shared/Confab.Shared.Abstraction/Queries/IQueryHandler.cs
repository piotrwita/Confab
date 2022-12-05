namespace Confab.Shared.Abstractions.Queries;

//przetworzenie kwerendy - zwrocenie danych
public interface IQueryHandler<in TQuery, TResult> where TQuery : class, IQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery command); 
}

namespace Confab.Shared.Abstractions.Queries;

//odpowiedzialny za wysylanie kwerendy 
public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
}
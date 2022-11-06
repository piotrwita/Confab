namespace Confab.Shared.Abstractions.Context;

public interface IIdentityContext
{
    bool IsAuthenticated { get; }
    Guid Id { get; }
    string Role { get; }
    Dictionary<string, IEnumerable<string>> Claims { get; }
}

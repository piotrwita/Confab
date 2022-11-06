using Confab.Shared.Abstractions.Context;

namespace Confab.Shared.Infrastructure.Contexts;

internal interface IContextFactory
{
    IContext Create();
}

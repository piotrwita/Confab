using Confab.Shared.Abstractions.Context;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confab.Shared.Infrastructure.Contexts;

internal class Context : IContext
{
    public string RequestId { get; } = $"{Guid.NewGuid():N}";
    public string TraceId { get; }
    public IIdentityContext Identity { get; }

    public Context(HttpContext context) : this(context.TraceIdentifier, new IdentityContext(context.User))
    {

    }

    internal Context()
    {
    }

    internal Context(string traceId, IIdentityContext identity)
    {
        TraceId = traceId;
        Identity = identity;
    }

    public static IContext Empty() => new Context();
}

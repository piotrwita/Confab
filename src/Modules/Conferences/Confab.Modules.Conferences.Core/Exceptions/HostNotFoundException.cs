using Confab.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confab.Modules.Conferences.Core.Exceptions;

internal class HostNotFoundException : ConfabException
{
    public Guid Id { get; }

    public HostNotFoundException(Guid id) : base($"Host with ID: {id} was not found.")
    {
        Id = id;
    }
}

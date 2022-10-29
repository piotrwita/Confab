using Confab.Shared.Abstraction.Exceptions;

namespace Confab.Modules.Speakers.Core.Exceptions;

internal class SpeakerAlreadyExistsException : ConfabException
{
    public Guid Id { get; }

    public SpeakerAlreadyExistsException(Guid id) : base($"Speaker with ID: {id} already exists.")
    {
        Id = id;
    }
}

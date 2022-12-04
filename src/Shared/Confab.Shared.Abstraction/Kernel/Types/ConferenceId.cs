namespace Confab.Shared.Abstractions.Kernel.Types;

public class ConferenceId : TypeId
{
    public ConferenceId(Guid value) : base(value)
    {
    }

    //implicit operator w druga strone (niz w TypeId)
    public static implicit operator ConferenceId(Guid id) => new(id);
}
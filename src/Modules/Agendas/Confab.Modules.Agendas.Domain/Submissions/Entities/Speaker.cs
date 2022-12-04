using Confab.Shared.Abstractions.Kernel.Types;

namespace Confab.Modules.Agendas.Domain.Submissions.Entities;

public sealed class Speaker : AggregateRoot
{
    public string FullName { get; init; }

    public Speaker(AggregateId id, string fullName)
    {
        Id = id;
        FullName = fullName;
    }

    //static factory
    //jezeli chcemu utworzyc dany agregat bedziemy stosowac dedykowana fabrykre 
    //dzieki temu jest rozroznienie miedzy odtwarzaniem obiektu a jego pierwotnym utworzeniem
    public static Speaker Create(Guid id, string fullName)
        => new Speaker(id, fullName);
}

namespace Confab.Shared.Abstractions.Kernel.Types;

public abstract class AggregateRoot<T>
{
    public T Id { get; protected set; }
    public int Version { get; protected set; }
    public IEnumerable<IDomainEvent> Events => _events;

    private readonly List<IDomainEvent> _events = new();
    //zabezpieczenie - wersja podbija sie jednokrotnie, nawet jesli zdarzen domenowych jest kilka
    private bool _versionIncremented;

    //wersja podbija sie przez dodanie zdarzenia domenowego
    protected void AddEvent(IDomainEvent @event)
    {
        //czy pierwsze zdarzenie w agregacie (nie mamy zadnych dodanych)
        //wersja podbija sie jednokrotnie, nawet jesli zdarzen domenowych jest kilka
        if(!_events.Any() && !_versionIncremented)
        {
            Version++;
            _versionIncremented = true;
        }

        _events.Add(@event);
    }

    public void ClearEvents() => _events.Clear();

    //podbicie wersji
    protected void IncrementVersion()
    {
        if (_versionIncremented)
        {
            return;
        }            

        Version++;
        _versionIncremented = true;
    }
}

public abstract class AggregateRoot : AggregateRoot<AggregateId>
{
}

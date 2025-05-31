namespace Booking.Core.Domain;

public abstract class BaseEntity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;
    
    public DateTimeOffset CreatedAt { get; set; }
    
    public void RaiseEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    
    public void ClearEvents() => _domainEvents.Clear();
}
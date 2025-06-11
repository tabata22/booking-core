namespace Booking.Core.Domain.CompanyAggregate.Events;

public record CompanyCreatedDomainEvent(long Id) : IDomainEvent;
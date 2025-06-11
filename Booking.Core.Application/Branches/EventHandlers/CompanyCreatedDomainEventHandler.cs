using Booking.Core.Domain.CompanyAggregate.Events;
using MediatR;

namespace Booking.Core.Application.Branches.EventHandlers;

public class CompanyCreatedDomainEventHandler : INotificationHandler<CompanyCreatedDomainEvent>
{
    public async Task Handle(CompanyCreatedDomainEvent @event, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
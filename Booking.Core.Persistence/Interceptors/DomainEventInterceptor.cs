using Booking.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Booking.Core.Persistence.Interceptors;

public class DomainEventInterceptor: SaveChangesInterceptor
{
    private readonly IMediator _mediator;

    public DomainEventInterceptor(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = default)
    {
        return result;
        var context = eventData.Context;
        if (context == null) 
            return result;
        
        var domainEntities = context.ChangeTracker
            .Entries<BaseEntity>()
            .Where(x => x.Entity.DomainEvents.Any())
            .Select(x => x.Entity)
            .ToList();
        
        var domainEvents = domainEntities
            .SelectMany(x => x.DomainEvents)
            .ToList();
        
        domainEntities.ForEach(x => x.ClearEvents());

        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent, cancellationToken);
        }
        
        return result;
    }
}
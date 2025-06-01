using Booking.Core.Application.Identities;
using Booking.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Booking.Core.Persistence.Interceptors;

public class AuditSaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly IUserService _userService;

    public AuditSaveChangesInterceptor(IUserService userService)
    {
        _userService = userService;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;
        if (context == null) 
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        var customerId = _userService.UserId;
        var now = DateTimeOffset.UtcNow;
        
        foreach (var entry in context.ChangeTracker.Entries<AuditableEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = now;
                entry.Entity.UpdatedAt = now;
                entry.Entity.CreatedBy = customerId;
                entry.Entity.UpdatedBy = customerId;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = now;
                entry.Entity.UpdatedBy = customerId;
            }
            else if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.Entity.DeletedAt = now;
                entry.Entity.DeletedBy = customerId;
            }
        }
        
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
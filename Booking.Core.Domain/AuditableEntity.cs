namespace Booking.Core.Domain;

public abstract class AuditableEntity : BaseEntity
{
    public Guid CreatedBy { get; set; }
    
    public Guid UpdatedBy { get; set; }
    
    public Guid DeletedBy { get; set; }
    
    public DateTimeOffset UpdatedAt { get; set; }
    
    public DateTimeOffset DeletedAt { get; set; }
}
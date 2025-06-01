using Booking.Core.Domain.BranchAggregate;
using Booking.Core.Domain.CompanyAggregate.Events;
using Booking.Core.Domain.CustomerAggregate;
using Booking.Core.Domain.PackageAggregate;
using Booking.Core.Domain.ServiceAggregate;

namespace Booking.Core.Domain.CompanyAggregate;

public class Company : AuditableEntity
{
    public Company(
        long packageId,
        string identificationCode,
        string name, 
        CompanyActivityType activityType,
        Guid? logoUrl, 
        string? description)
    {
        PackageId = packageId;
        IdentificationCode = identificationCode;
        Name = name;
        Status = CompanyStatus.Pending;
        ActivityType = activityType;
        LogoUrl = logoUrl;
        Description = description;
        
        RaiseEvent(new CompanyCreatedDomainEvent());
    }
    
    private Company() {}

    public long Id { get; private set; }
    
    public long PackageId { get; private set; }
    
    public string IdentificationCode { get; private set; }
    
    public string Name { get; private set; }
    
    public CompanyStatus Status { get; private set; }
    
    public CompanyActivityType ActivityType { get; private set; }
    
    public Guid? LogoUrl { get; private set; }
    
    public string? Description { get; private set; }
    
    public Package Package { get; private set; }
    
    public ICollection<Customer> Customers { get; private set; }
    
    public ICollection<Branch> Branches { get; private set; }

    public void Update(
        long packageId,
        string identificationCode,
        string name, 
        CompanyActivityType activityType,
        Guid? logoUrl, 
        string? description)
    {
        PackageId = packageId;
        IdentificationCode = identificationCode;
        Name = name;
        ActivityType = activityType;
        LogoUrl = logoUrl;
        Description = description;
    }
    
    public void Activate()
    {
        Status = CompanyStatus.Active;
    }
    
    public void DeActivate()
    {
        Status = CompanyStatus.Deactivated;
    }
}
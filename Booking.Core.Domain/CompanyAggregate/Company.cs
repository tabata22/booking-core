using Booking.Core.Domain.CompanyAggregate.Events;
using Booking.Core.Domain.CustomerAggregate;
using Booking.Core.Domain.ServiceAggregate;

namespace Booking.Core.Domain.CompanyAggregate;

public class Company : BaseEntity
{
    public Company(
        string identificationCode,
        string name, 
        CompanyActivityType activityType,
        Guid? logoUrl, 
        string? description, 
        string address, 
        double? latitude, 
        double? longitude, 
        string? googleMapPlaceId)
    {
        IdentificationCode = identificationCode;
        Name = name;
        Status = CompanyStatus.Pending;
        ActivityType = activityType;
        LogoUrl = logoUrl;
        Description = description;
        Address = new CompanyAddress(address, latitude, longitude, googleMapPlaceId);
        
        RaiseEvent(new CompanyCreatedDomainEvent());
    }
    
    private Company() {}

    public long Id { get; private set; }
    
    public string IdentificationCode { get; private set; }
    
    public string Name { get; private set; }
    
    public CompanyStatus Status { get; private set; }
    
    public CompanyActivityType ActivityType { get; private set; }
    
    public Guid? LogoUrl { get; private set; }
    
    public string? Description { get; private set; }
    
    public CompanyAddress Address { get; private set; }
    
    public ICollection<Customer> Customers { get; private set; }
    
    public ICollection<CompanyService> Services { get; private set; }
    
    public ICollection<Branch> Branches { get; private set; }
    
    public void AddService(CompanyService service) => Services.Add(service);

    public void Activate()
    {
        Status = CompanyStatus.Active;
    }
    
    public void DeActivate()
    {
        Status = CompanyStatus.Deactivated;
    }
}
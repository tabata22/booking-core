using Booking.Core.Domain.CompanyAggregate;
using Booking.Core.Domain.EmployeeAggregate;
using Booking.Core.Domain.ServiceAggregate;

namespace Booking.Core.Domain.BranchAggregate;

public class Branch : AuditableEntity
{
    public Branch(
        long companyId, 
        string name,
        string address, 
        double? latitude, 
        double? longitude, 
        string? googleMapPlaceId)
    {
        CompanyId = companyId;
        Name = name;
        Address = new BranchAddress(address, latitude, longitude, googleMapPlaceId);
    }
    
    private Branch() { }

    public long Id { get; private set; }
    
    public long CompanyId { get; private set; }
    
    public string Name { get; private set; }
    
    public BranchAddress Address { get; private set; }
    
    public Company Company { get; private set; }
    
    public ICollection<Employee> Employees { get; private set; }
    
    public ICollection<Service> Services { get; private set; }

    public void Update(
        string name,
        string address, 
        double? latitude, 
        double? longitude, 
        string? googleMapPlaceId)
    {
        Name = name;
        Address = new BranchAddress(address, latitude, longitude, googleMapPlaceId);
    }
}
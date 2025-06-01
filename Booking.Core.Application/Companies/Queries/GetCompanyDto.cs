using Booking.Core.Domain.CompanyAggregate;

namespace Booking.Core.Application.Companies.Queries;

public class GetCompanyDto
{
    public long Id { get; set; }
    
    public string IdentificationCode { get; set; }
    
    public string Name { get; set; }
    
    public CompanyStatus Status { get; set; }
    
    public CompanyActivityType ActivityType { get; set; }
    
    public Guid? LogoUrl { get; set; }
    
    public string? Description { get; set; }
}
using Booking.Core.Domain.CompanyAggregate;

namespace Booking.Core.Domain.CustomerAggregate;

public class Customer : BaseEntity
{
    public Customer(
        Guid id, 
        long companyId,
        string username, 
        string email, 
        string firstName,
        string lastName)
    {
        Id = id;
        CompanyId = companyId;
        Username = username;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
    
    private Customer() {}

    public Guid Id { get; private set; }
    
    public long CompanyId { get; private set; }
    
    public string Username { get; private set; }
    
    public string Email { get; private set; }
    
    public string FirstName { get; private set; }
    
    public string LastName { get; private set; }
    
    public Company Company { get; private set; }
}
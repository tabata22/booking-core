namespace Booking.Core.Application.Identities;

public interface IUserService
{
    Guid UserId  { get; }
    
    long CompanyId  { get; }
}
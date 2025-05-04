namespace Booking.Core.Application.Identities;

public interface IIdentityProviderService
{
    Task CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken);
}
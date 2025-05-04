using System.Net.Http.Json;
using Booking.Core.Application.Identities;

namespace Booking.Core.Infrastructure.Identities;

public class IdentityProviderService :  IIdentityProviderService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public IdentityProviderService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        using var client = _httpClientFactory.CreateClient();
        
        var userPayload = new
        {
            username = "newuser",
            enabled = true,
            emailVerified = true,
            email = request.Email,
            firstName = "New",
            lastName = "User",
            credentials = new[]
            {
                new 
                {
                    type = "password",
                    value = request.Password,
                    temporary = true
                }
            }
        };

        var response = await client.PostAsJsonAsync("http://localhost:8080/admin/realms/your_realm/users", userPayload, cancellationToken);
        
        response.EnsureSuccessStatusCode();
    }
}
using Booking.Core.Application.Identities;
using Microsoft.AspNetCore.Http;

namespace Booking.Core.Infrastructure.Identities;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor  _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId => Guid.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
}
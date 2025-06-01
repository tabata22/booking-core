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

    public Guid UserId => Guid.Parse("dfbb7460-de34-46e6-b1b8-01494ce41833");
    public long CompanyId { get; }
}
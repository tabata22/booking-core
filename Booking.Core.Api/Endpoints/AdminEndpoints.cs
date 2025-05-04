namespace Booking.Core.Api.Endpoints;

public static class AdminEndpoints
{
    public static RouteGroupBuilder RegisterAdminEndpoints(this RouteGroupBuilder routeGroup)
    {
        var adminGroup = routeGroup.MapGroup("/admins")
            .WithTags("Admin");
        
        return adminGroup;
    }
}
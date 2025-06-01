using Booking.Core.Application.Identities;
using Booking.Core.Application.Services.Queries;

namespace Booking.Core.Api.Endpoints;

public static class ServiceEndpoints
{
    public static RouteGroupBuilder RegisterServiceEndpoints(this RouteGroupBuilder routeGroup)
    {
        var serviceGroup = routeGroup.MapGroup("/services")
            .WithTags("Service");

        serviceGroup.MapGet("/", async (
            IServiceQueries queries,
            IUserService userService,
            CancellationToken cancellationToken = default
            ) =>
            {
                var services = await queries.GetAll(userService.CompanyId, cancellationToken);
                
                return Results.Ok(services);
            });
        
        return serviceGroup;
    }
}
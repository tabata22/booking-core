using Booking.Core.Application.Services;

namespace Booking.Core.Api.Endpoints;

public static class ServiceEndpoints
{
    public static RouteGroupBuilder RegisterServiceEndpoints(this RouteGroupBuilder routeGroup)
    {
        var serviceGroup = routeGroup.MapGroup("/services")
            .WithTags("Service");

        serviceGroup.MapGet("/", async (
            IServiceQuery query,
            CancellationToken cancellationToken = default
            ) =>
            {
                var services = await query.GetAll(cancellationToken);
                
                return Results.Ok(services);
            });
        
        return serviceGroup;
    }
}
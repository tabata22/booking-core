using Booking.Core.Application.Identities;
using Booking.Core.Application.Services.Commands;
using Booking.Core.Application.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Core.Api.Endpoints;

public static class ServiceEndpoints
{
    public static RouteGroupBuilder RegisterServiceEndpoints(this RouteGroupBuilder routeGroup)
    {
        var serviceGroup = routeGroup.MapGroup("/services")
            .WithTags("Service");

        serviceGroup.MapPost("/", async (
            [FromServices] IMediator mediator,
            [FromBody] CreateServiceCommand command,
            CancellationToken cancellationToken = default
            ) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            
            return result.ToResponse();
        });
        
        serviceGroup.MapPut("/", async (
            [FromServices] IMediator mediator,
            [FromBody] UpdateServiceCommand command,
            CancellationToken cancellationToken = default
        ) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            
            return result.ToResponse();
        });
        
        serviceGroup.MapDelete("/{id:long}", async (
            [FromServices] IMediator mediator,
            long id,
            CancellationToken cancellationToken = default
        ) =>
        {
            var command = new DeleteServiceCommand(id);
            var result = await mediator.Send(command, cancellationToken);
            
            return result.ToResponse();
        });

        serviceGroup.MapGet("/", async (
            [FromServices] IServiceQueries queries,
            [FromServices] IUserService userService,
            CancellationToken cancellationToken = default
            ) =>
            {
                var services = await queries.GetAll(userService.CompanyId, cancellationToken);
                
                return Results.Ok(services);
            });
        
        return serviceGroup;
    }
}
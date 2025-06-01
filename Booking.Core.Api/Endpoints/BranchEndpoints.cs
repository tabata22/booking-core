using Booking.Core.Application.Branches.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Core.Api.Endpoints;

public static class BranchEndpoints
{
    public static RouteGroupBuilder RegisterBranchEndpoints(this RouteGroupBuilder routeGroup)
    {
        var group = routeGroup.MapGroup("/branches")
            .WithTags("Branch");

        group.MapPost("/", async (
            [FromServices] IMediator mediator,
            [FromBody] CreateBranchCommand command,
           CancellationToken cancellationToken = default
            ) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            
            return result.ToResponse();
        });
        
        group.MapPut("/", async (
            [FromServices]IMediator mediator,
            [FromBody]UpdateBranchCommand command,
            CancellationToken cancellationToken = default
        ) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            
            return result.ToResponse();
        });
        
        group.MapDelete("/", async (
            [FromServices] IMediator mediator,
            [FromBody] DeleteBranchCommand command,
            CancellationToken cancellationToken = default
        ) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            
            return result.ToResponse();
        });
        
        return group;
    }
}
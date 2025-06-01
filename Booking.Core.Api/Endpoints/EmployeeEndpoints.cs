using Booking.Core.Application.Employees.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Core.Api.Endpoints;

public static class EmployeeEndpoints
{
    public static RouteGroupBuilder RegisterEmployeeEndpoints(this RouteGroupBuilder routeGroup)
    {
        var employeeGroup = routeGroup.MapGroup("/employees")
            .WithTags("Employee");
        
        employeeGroup.MapPost("/", async (
            [FromServices] IMediator mediator,
            [FromBody] CreateEmployeeCommand command,
            CancellationToken cancellationToken = default
        ) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                return Results.Ok();
            }
            
            return Results.BadRequest();
        });
        
        employeeGroup.MapPut("/", async (
            [FromServices] IMediator mediator,
            [FromBody] UpdateEmployeeCommand command,
            CancellationToken cancellationToken = default
        ) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                return Results.Ok();
            }
            
            return Results.BadRequest();
        });
        
        employeeGroup.MapDelete("{id:long}", async (
            [FromServices] IMediator mediator,
            long id,
            CancellationToken cancellationToken = default
        ) =>
        {
            var command = new DeleteEmployeeCommand(id);
            await mediator.Send(command, cancellationToken);
            
            return Results.Ok();
        });
        
        return employeeGroup;
    }
}
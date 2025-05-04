using Booking.Core.Application.Employees.Create;
using Booking.Core.Application.Employees.Delete;
using Booking.Core.Application.Employees.Update;
using MediatR;

namespace Booking.Core.Api.Endpoints;

public static class EmployeeEndpoints
{
    public static RouteGroupBuilder RegisterEmployeeEndpoints(this RouteGroupBuilder routeGroup)
    {
        var employeeGroup = routeGroup.MapGroup("/employees")
            .WithTags("Employee");
        
        employeeGroup.MapPost("/", async (
            IMediator mediator,
            CreateEmployeeCommand command,
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
            IMediator mediator,
            UpdateEmployeeCommand command,
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
            IMediator mediator,
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
using Booking.Core.Application.Companies;
using Booking.Core.Application.Companies.Commands;
using Booking.Core.Application.Identities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Core.Api.Endpoints;

public static class CompanyEndpoints
{
    public static RouteGroupBuilder RegisterCompanyEndpoints(this RouteGroupBuilder routeGroup)
    {
        var companyGroup = routeGroup.MapGroup("/companies")
            .WithTags("Company");
        
        companyGroup.MapGet("{id:long}", async (
            [FromServices] ICompanyRepository repository,
            long id,
            CancellationToken cancellationToken = default
        ) =>
        {
            var company = await repository.GetOneAsync(x => x.Id == id, cancellationToken);
            if (company is null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(company);
        });

        companyGroup.MapPost("/", async (
                [FromServices] IMediator mediator,
            [FromBody] CreateCompanyCommand command,
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
        
        companyGroup.MapPut("/", async (
            [FromServices] IMediator mediator,
            [FromBody] UpdateCompanyCommand command,
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
        
        return companyGroup;
    }
}
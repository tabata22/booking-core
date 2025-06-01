using Booking.Core.Application.Companies;
using Booking.Core.Application.Companies.Commands;
using Booking.Core.Application.Identities;
using MediatR;

namespace Booking.Core.Api.Endpoints;

public static class CompanyEndpoints
{
    public static RouteGroupBuilder RegisterCompanyEndpoints(this RouteGroupBuilder routeGroup)
    {
        var companyGroup = routeGroup.MapGroup("/companies")
            .WithTags("Company");
        
        companyGroup.MapGet("{id:long}", async (
            ICompanyRepository repository,
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
            IMediator mediator,
            CreateCompanyCommand command,
            CancellationToken cancellationToken = default
            ) =>
            {
                var result = await mediator.Send(command, cancellationToken);
                if (result.IsSuccess)
                {
                    return Results.Ok();
                }
                
                return Results.BadRequest();
            })
            .RequireAuthorization(AuthorizationPolicies.AdminPolicy);
        
        companyGroup.MapPut("/", async (
            IMediator mediator,
            UpdateCompanyCommand command,
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
using Booking.Core.Domain.CompanyAggregate;
using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Companies.Commands;

public record UpdateCompanyCommand(
    long Id, 
    long PackageId,
    string IdentificationCode,
    string Name,
    CompanyActivityType CompanyActivityType,
    string? Description) : IRequest<Result>;
    
public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Result>
{
    private readonly ICompanyRepository _repository;

    public UpdateCompanyCommandHandler(ICompanyRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result> Handle(UpdateCompanyCommand command, CancellationToken cancellationToken)
    {
        var company = await _repository.GetForUpdateAsync(x => x.Id == command.Id, cancellationToken);
        if (company == null)
        {
            return Result.Failure("Company not found");
        }
        
        company.Update(
            command.PackageId,
            command.IdentificationCode,
            command.Name,
            command.CompanyActivityType,
            null,
            command.Description);
        
        await _repository.UpdateAsync(company, cancellationToken);
        await _repository.SaveAsync(cancellationToken);
        
        return Result.Success();
    }
}
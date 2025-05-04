using Booking.Core.Domain.CompanyAggregate;
using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Companies.Create;

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Result>
{
    private readonly ICompanyRepository _repository;

    public CreateCompanyCommandHandler(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
    {
        var isExists = await _repository.ExistsAsync(x => x.IdentificationCode == command.IdentificationCode, cancellationToken);
        if (isExists)
        {
            return Result.Failure("Company with the same Identification Code already exists");
        }

        var company = new Company(
            command.IdentificationCode,
            command.Name,
            command.CompanyActivityType,
            null,
            command.Description,
            command.Address,
            command.Latitude,
            command.Longitude,
            command.GoogleMapPlaceId
            );

        foreach (var serviceId in command.Services)
        {
            var companyService = new CompanyService
            {
                Id = Guid.NewGuid(),
                ServiceId = serviceId
            };
            
            company.AddService(companyService);
        }
        
        await _repository.AddAsync(company, cancellationToken);
        await _repository.SaveAsync(cancellationToken);
        
        return Result.Success();
    }
}
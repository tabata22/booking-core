using Booking.Core.Domain.ServiceAggregate;
using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Services.Create;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Result>
{
    private readonly IServiceRepository _serviceRepository;

    public CreateServiceCommandHandler(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<Result> Handle(CreateServiceCommand command, CancellationToken cancellationToken)
    {
        var service = new Service(command.Name, command.Description, command.Price, command.Duration);
        
        await _serviceRepository.AddAsync(service, cancellationToken);
        await _serviceRepository.SaveAsync(cancellationToken);
        
        return Result.Success();
    }
}
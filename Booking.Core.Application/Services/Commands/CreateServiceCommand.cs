using Booking.Core.Application.Identities;
using Booking.Core.Domain.ServiceAggregate;
using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Services.Commands;

public record CreateServiceCommand(
    string Name, 
    string? Description, 
    decimal Price, 
    int Duration) : IRequest<Result>;
    
public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Result>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IUserService  _userService;

    public CreateServiceCommandHandler(IServiceRepository serviceRepository, IUserService userService)
    {
        _serviceRepository = serviceRepository;
        _userService = userService;
    }

    public async Task<Result> Handle(CreateServiceCommand command, CancellationToken cancellationToken)
    {
        var service = new Service(
            _userService.CompanyId,
            command.Name, 
            command.Description, 
            command.Price, 
            command.Duration);
        
        await _serviceRepository.AddAsync(service, cancellationToken);
        await _serviceRepository.SaveAsync(cancellationToken);
        
        return Result.Success();
    }
}
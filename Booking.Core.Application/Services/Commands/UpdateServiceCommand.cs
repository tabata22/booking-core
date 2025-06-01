using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Services.Commands;

public record UpdateServiceCommand(
    long Id,
    string Name, 
    string? Description, 
    decimal Price, 
    int Duration) : IRequest<Result>;
    
public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Result>
{
    private readonly IServiceRepository _serviceRepository;

    public UpdateServiceCommandHandler(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<Result> Handle(UpdateServiceCommand command, CancellationToken cancellationToken)
    {
        var service = await _serviceRepository.GetForUpdateAsync(command.Id, cancellationToken);
        if (service is null)
        {
            return Result.Failure("service not found");
        }
        
        service.Update(
            command.Name,
            command.Description,
            command.Price,
            command.Duration);
        
        await _serviceRepository.UpdateAsync(service, cancellationToken);
        await _serviceRepository.SaveAsync(cancellationToken);
        
        return Result.Success();
    }
}
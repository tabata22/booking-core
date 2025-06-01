using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Services.Commands;

public record DeleteServiceCommand(long Id) : IRequest<Result>;

public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, Result>
{
    private readonly IServiceRepository _serviceRepository;

    public DeleteServiceCommandHandler(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<Result> Handle(DeleteServiceCommand command, CancellationToken cancellationToken)
    {
        var service = await _serviceRepository.GetForUpdateAsync(command.Id, cancellationToken);
        if (service is null)
        {
            return Result.Success();
        }

        _serviceRepository.Delete(service);
        await _serviceRepository.SaveAsync(cancellationToken);
        
        return Result.Success();
    }
}
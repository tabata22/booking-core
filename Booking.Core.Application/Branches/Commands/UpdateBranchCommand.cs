using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Branches.Commands;

public record UpdateBranchCommand(
    long Id,
    string Name,
    string Address, 
    double? Latitude, 
    double? Longitude, 
    string? GoogleMapPlaceId) : IRequest<Result>;
    
public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, Result>
{
    private readonly IBranchRepository _branchRepository;

    public UpdateBranchCommandHandler(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }
    
    public async Task<Result> Handle(UpdateBranchCommand command, CancellationToken cancellationToken)
    {
        var branch = await _branchRepository.GetForUpdateAsync(command.Id, cancellationToken);
        if (branch == null)
        {
            return Result.Failure("Branch not found");
        }
        
        branch.Update(
            command.Name,
            command.Address,
            command.Latitude,
            command.Longitude,
            command.GoogleMapPlaceId);
        
        await _branchRepository.UpdateAsync(branch, cancellationToken);
        await _branchRepository.SaveAsync(cancellationToken);
        
        return Result.Success();
    }
}
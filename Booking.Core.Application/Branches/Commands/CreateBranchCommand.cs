using Booking.Core.Application.Identities;
using Booking.Core.Domain.BranchAggregate;
using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Branches.Commands;

public record CreateBranchCommand (
    string Name,
    string Address, 
    double? Latitude, 
    double? Longitude, 
    string? GoogleMapPlaceId) : IRequest<Result>;

public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, Result>
{
    private readonly IBranchRepository _branchRepository;
    private readonly IUserService _userService;

    public CreateBranchCommandHandler(IBranchRepository branchRepository, IUserService userService)
    {
        _branchRepository = branchRepository;
        _userService = userService;
    }

    public async Task<Result> Handle(CreateBranchCommand command, CancellationToken cancellationToken)
    {
        var branch = new Branch(
            _userService.CompanyId,
            command.Name,
            command.Address,
            command.Latitude,
            command.Longitude,
            command.GoogleMapPlaceId);
        
        await _branchRepository.AddAsync(branch, cancellationToken);
        await _branchRepository.SaveAsync(cancellationToken);
        
        return Result.Success();
    }
} 
using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Branches.Commands;

public record DeleteBranchCommand(long Id) : IRequest<Result>;

public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, Result>
{
    private readonly IBranchRepository _branchRepository;

    public DeleteBranchCommandHandler(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<Result> Handle(DeleteBranchCommand command, CancellationToken cancellationToken)
    {
        var branch = await _branchRepository.GetForUpdateAsync(command.Id, cancellationToken);
        if (branch == null)
        {
            return Result.Success();
        }
        
        _branchRepository.Delete(branch);
        await _branchRepository.SaveAsync(cancellationToken);
        
        return Result.Success();
    }
}
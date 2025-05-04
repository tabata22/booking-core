using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Employees.Delete;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Result>
{
    private readonly IEmployeeRepository _employeeRepository;

    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Result> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
    {
        await _employeeRepository.DeleteAsync(x => x.Id == command.Id, cancellationToken);
        await _employeeRepository.SaveAsync(cancellationToken);
        
        return Result.Success();
    }
}
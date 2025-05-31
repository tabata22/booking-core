using Booking.Core.Domain.EmployeeAggregate;
using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Employees.Update;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Result>
{
    private readonly IEmployeeRepository _repository;

    public UpdateEmployeeCommandHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetForUpdateAsync(x => x.Id == command.Id, cancellationToken);
        if (employee is null)
        {
            return Result.Failure("Employee not found");
        }
        
        employee.Services.Clear();
        
        employee.Update(command.BranchId, command.FirstName, command.LastName);
        foreach (var serviceId in command.Services)
        {
            var employeeService = new EmployeeService
            {
                Id = Guid.NewGuid(),
                ServiceId = serviceId
            };
            
            employee.AddService(employeeService);
        }

        await _repository.UpdateAsync(employee, cancellationToken);
        await _repository.SaveAsync(cancellationToken);
        
        return Result.Success();
    }
}
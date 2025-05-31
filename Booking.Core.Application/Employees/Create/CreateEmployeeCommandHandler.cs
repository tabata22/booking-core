using Booking.Core.Domain.EmployeeAggregate;
using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Employees.Create;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result>
{
    private readonly IEmployeeRepository _repository;

    public CreateEmployeeCommandHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var employee = new Employee(command.BranchId, command.FirstName, command.LastName);
        foreach (var serviceId in command.Services)
        {
            var employeeService = new EmployeeService
            {
                Id = Guid.NewGuid(),
                ServiceId = serviceId
            };
            
            employee.AddService(employeeService);
        }
        
        await _repository.AddAsync(employee, cancellationToken);
        await _repository.SaveAsync(cancellationToken);
        
        return Result.Success();
    }
}
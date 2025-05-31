using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Employees.Create;

public record CreateEmployeeCommand(
    long BranchId,
    string FirstName,
    string? LastName, 
    long[] Services) : IRequest<Result>;
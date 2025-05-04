using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Employees.Update;

public record UpdateEmployeeCommand(
    long Id, 
    string FirstName, 
    string? LastName, 
    long[] Services) : IRequest<Result>;
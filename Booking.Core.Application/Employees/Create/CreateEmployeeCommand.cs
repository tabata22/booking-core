using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Employees.Create;

public record CreateEmployeeCommand(string FirstName, string? LastName, long[] Services) : IRequest<Result>;
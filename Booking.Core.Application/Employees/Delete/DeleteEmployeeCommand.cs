using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Employees.Delete;

public record DeleteEmployeeCommand(long Id) : IRequest<Result>;
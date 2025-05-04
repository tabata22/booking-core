using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Services.Create;

public record CreateServiceCommand(
    string Name, 
    string? Description, 
    decimal Price, 
    long Duration) : IRequest<Result>;
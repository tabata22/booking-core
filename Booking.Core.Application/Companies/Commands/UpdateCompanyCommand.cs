using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Companies.Commands;

public record UpdateCompanyCommand() : IRequest<Result>;
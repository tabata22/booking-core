using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Companies.Update;

public record UpdateCompanyCommand() : IRequest<Result>;
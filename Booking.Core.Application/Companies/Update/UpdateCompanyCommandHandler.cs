using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Companies.Update;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Result>
{
    public Task<Result> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
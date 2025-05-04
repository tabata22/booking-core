using Booking.Core.Application.Services.Models;

namespace Booking.Core.Application.Services;

public interface IServiceQuery
{
    Task<IReadOnlyList<ServiceModel>> GetAll(CancellationToken cancellationToken = default);
}
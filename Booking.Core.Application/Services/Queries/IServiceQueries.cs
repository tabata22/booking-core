namespace Booking.Core.Application.Services.Queries;

public interface IServiceQueries
{
    Task<IReadOnlyList<GetServiceDto>> GetAll(long companyId, CancellationToken cancellationToken = default);
}
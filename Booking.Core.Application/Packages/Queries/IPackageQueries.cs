namespace Booking.Core.Application.Packages.Queries;

public interface IPackageQueries
{
    Task<IReadOnlyList<GetPackageDto>> GetPackagesAsync(CancellationToken cancellationToken = default);
}
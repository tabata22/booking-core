using System.Collections.Concurrent;
using Booking.Core.Application.Services;
using Booking.Core.Domain.ServiceAggregate;

namespace Booking.Core.Infrastructure.Cache;

public class ServiceCache :  IServiceCache
{
    private readonly IServiceRepository _serviceRepository;
    private readonly ConcurrentDictionary<long, Service> _cache = new();

    public ServiceCache(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task LoadAsync(CancellationToken cancellationToken = default)
    {
        var services = await _serviceRepository.GetAllAsync(cancellationToken);
        foreach (var service in services)
        {
            _cache.TryAdd(service.Id, service);
        }
    }

    public IReadOnlyList<Service> GetAll() => _cache.Select(x => x.Value).ToList();

    public Service Get(long key) => _cache[key];
}
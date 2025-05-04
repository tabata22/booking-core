using Microsoft.Extensions.DependencyInjection;

namespace Booking.Core.Application;

public static class ServiceCollections
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
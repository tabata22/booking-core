using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Core.Persistence;

public static class ServiceCollections
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,  IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>();
        
        return services;
    }
}
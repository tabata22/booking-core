using Booking.Core.Application.Companies.Queries;
using Booking.Core.Application.Packages.Queries;
using Booking.Core.Persistence.Companies;
using Booking.Core.Persistence.Interceptors;
using Booking.Core.Persistence.Packages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Core.Persistence;

public static class ServiceCollections
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,  IConfiguration configuration)
    {
        services.AddScoped<DomainEventInterceptor>();
        services.AddScoped<AuditSaveChangesInterceptor>();
        
        services.AddDbContext<ApplicationDbContext>((sp, options) 
            => options.UseNpgsql(configuration.GetConnectionString("MasterConnection"))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(
                    sp.GetRequiredService<DomainEventInterceptor>(),
                    sp.GetRequiredService<AuditSaveChangesInterceptor>()));

        services.AddScoped<ICompanyQueries, CompanyQueries>();
        services.AddScoped<IPackageQueries, PackageQueries>();
        
        return services;
    }
}
using Booking.Core.Application.Branches;
using Booking.Core.Application.Companies;
using Booking.Core.Application.Companies.Queries;
using Booking.Core.Application.Employees;
using Booking.Core.Application.Packages.Queries;
using Booking.Core.Application.Services;
using Booking.Core.Persistence.Branches;
using Booking.Core.Persistence.Companies;
using Booking.Core.Persistence.Employees;
using Booking.Core.Persistence.Interceptors;
using Booking.Core.Persistence.Packages;
using Booking.Core.Persistence.Services;
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

        services.AddScoped<IBranchRepository, BranchRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        
        services.AddScoped<ICompanyQueries, CompanyQueries>();
        services.AddScoped<IPackageQueries, PackageQueries>();
        
        return services;
    }
}
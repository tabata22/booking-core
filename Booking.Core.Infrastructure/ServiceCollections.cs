using Booking.Core.Application.Blobs;
using Booking.Core.Application.Identities;
using Booking.Core.Application.Services;
using Booking.Core.Infrastructure.Blobs;
using Booking.Core.Infrastructure.Cache;
using Booking.Core.Infrastructure.Identities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Core.Infrastructure;

public static class ServiceCollections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration  configuration)
    {
        services.AddAuthentication(options => 
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "http://localhost:8081/realms/booking";
                options.RequireHttpsMetadata = false; // only in dev
                options.Audience = "core-api";
            });

        services.AddAuthorizationBuilder()
            .AddPolicy(AuthorizationPolicies.AdminPolicy, policy => policy
                    .RequireAuthenticatedUser()
                    .RequireRole("admin"))
            .AddPolicy(AuthorizationPolicies.CustomerPolicy, policy => policy
                    .RequireAuthenticatedUser()
                    .RequireRole("customer"));
        
        services.AddHttpContextAccessor();

        services.AddScoped<IBlobService, BlobService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IIdentityProviderService, IdentityProviderService>();

        services.AddSingleton<IServiceCache, ServiceCache>();
        
        return services;
    }
}
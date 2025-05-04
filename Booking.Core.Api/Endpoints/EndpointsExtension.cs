namespace Booking.Core.Api.Endpoints;

public static class EndpointsExtension
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        var mainGroup = app.MapGroup("api/v1")
            .RequireAuthorization()
            .WithOpenApi();
        
        mainGroup.RegisterAdminEndpoints();
        mainGroup.RegisterCompanyEndpoints();
        mainGroup.RegisterEmployeeEndpoints();
        mainGroup.RegisterServiceEndpoints();
        
        return app;
    }
}
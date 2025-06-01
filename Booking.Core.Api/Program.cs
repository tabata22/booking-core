using Booking.Core.Api.Endpoints;
using Booking.Core.Application;
using Booking.Core.Infrastructure;
using Booking.Core.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    await MigrateAsync(app.Services);
}

// app.UseAuthentication();
// app.UseAuthorization();

app.UseHttpsRedirection();
app.RegisterEndpoints();

app.Run();

return;

async Task MigrateAsync(IServiceProvider serviceProvider)
{
    await using var scope = serviceProvider.CreateAsyncScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    await dbContext.Database.MigrateAsync();
}
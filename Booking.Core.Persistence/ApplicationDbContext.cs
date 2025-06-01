using System.Reflection;
using Booking.Core.Domain.CompanyAggregate;
using Booking.Core.Domain.CustomerAggregate;
using Booking.Core.Domain.EmployeeAggregate;
using Booking.Core.Domain.PackageAggregate;
using Booking.Core.Domain.ServiceAggregate;
using Microsoft.EntityFrameworkCore;

namespace Booking.Core.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<Company> Companies { get; set; }
    
    public DbSet<CompanyService> CompanyServices { get; set; }
    
    public DbSet<Employee> Employees { get; set; }
    
    public DbSet<EmployeeService> EmployeeServices { get; set; }
    
    public DbSet<Service> Services { get; set; }
    
    public DbSet<Package> Packages { get; set; }
}
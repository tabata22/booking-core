using Booking.Core.Domain.EmployeeAggregate;
using Booking.Core.Domain.ServiceAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Core.Persistence.Employees;

public class EmployeeEntityConfiguration : 
    IEntityTypeConfiguration<Employee>, 
    IEntityTypeConfiguration<EmployeeService>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employees");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.BranchId)
            .IsRequired();

        builder.Property(e => e.FirstName)
            .IsRequired();

        builder.Property(e => e.LastName);

        builder.HasOne(e => e.Branch)
            .WithMany(b => b.Employees)
            .HasForeignKey(e => e.BranchId);

        builder.HasMany(e => e.Services)
            .WithOne(e => e.Employee)
            .HasForeignKey(e => e.EmployeeId);
    }

    public void Configure(EntityTypeBuilder<EmployeeService> builder)
    {
        builder.ToTable("employee_services");
        
        builder.HasKey(e => e.Id);
        
        builder.Property(x => x.EmployeeId)
            .IsRequired();
        
        builder.Property(x => x.ServiceId)
            .IsRequired();
        
        builder.HasOne(e => e.Employee)
            .WithMany(b => b.Services)
            .HasForeignKey(e => e.EmployeeId);
        
        builder.HasOne(e => e.Service)
            .WithMany(b => b.EmployeeServices)
            .HasForeignKey(e => e.ServiceId);
    }
}
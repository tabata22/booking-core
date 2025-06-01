using Booking.Core.Domain.ServiceAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Core.Persistence.Services;

public class ServiceEntityConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("services");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .ValueGeneratedOnAdd();

        builder.Property(s => s.BranchId)
            .IsRequired();

        builder.Property(s => s.Name)
            .IsRequired();

        builder.Property(s => s.Description);

        builder.Property(s => s.Price)
            .IsRequired();

        builder.Property(s => s.Duration)
            .IsRequired();

        builder.HasOne(s => s.Branch)
            .WithMany(c => c.Services)
            .HasForeignKey(s => s.BranchId);
    }
}
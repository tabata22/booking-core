using Booking.Core.Domain.PackageAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Core.Persistence.Packages;

public class PackageEntityConfiguration : IEntityTypeConfiguration<Package>
{
    public void Configure(EntityTypeBuilder<Package> builder)
    {
        builder.ToTable("packages");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(x => x.Status)
            .IsRequired();
        
        builder.Property(x => x.Name)
            .IsRequired();
        
        builder.Property(x => x.Price)
            .IsRequired();
    }
}
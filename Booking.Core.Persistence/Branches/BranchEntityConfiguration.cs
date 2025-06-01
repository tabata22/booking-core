using Booking.Core.Domain.BranchAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Core.Persistence.Branches;

public class BranchEntityConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("branches");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        builder.Property(b => b.CompanyId)
            .IsRequired();

        builder.Property(b => b.Name)
            .IsRequired();
        
        builder.OwnsOne(c => c.Address, address =>
        {
            address.Property(a => a.Address)
                .HasColumnName("address")
                .IsRequired();

            address.Property(a => a.Latitude);

            address.Property(a => a.Longitude);

            address.Property(a => a.GoogleMapPlaceId);
        });

        builder.HasOne(b => b.Company)
            .WithMany(c => c.Branches)
            .HasForeignKey(b => b.CompanyId);

        builder.HasMany(b => b.Employees)
            .WithOne(b => b.Branch)
            .HasForeignKey(b => b.BranchId);
    }
}
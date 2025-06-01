using Booking.Core.Domain.CompanyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Core.Persistence.Companies;

public class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("companies");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.PackageId)
            .IsRequired();

        builder.Property(c => c.IdentificationCode)
            .IsRequired();

        builder.Property(c => c.Name)
            .IsRequired();

        builder.Property(c => c.Status)
            .IsRequired();

        builder.Property(c => c.ActivityType)
            .IsRequired();

        builder.Property(c => c.LogoUrl);

        builder.Property(c => c.Description);

        builder.HasOne(c => c.Package)
            .WithMany(c => c.Companies)
            .HasForeignKey(c => c.PackageId);

        builder.HasMany(c => c.Customers)
            .WithOne(c => c.Company)
            .HasForeignKey(c => c.CompanyId);

        builder.HasMany(c => c.Branches)
            .WithOne(c => c.Company)
            .HasForeignKey(c => c.CompanyId);
    }
}
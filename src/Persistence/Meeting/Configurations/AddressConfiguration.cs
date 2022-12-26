using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Person.Data;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Meeting.Configurations
{
    internal class AddressConfiguration : AuditMetadataConfiguration<AddressData>
    {
        public override void Configure(EntityTypeBuilder<AddressData> builder)
        {
            builder
                .ToTable("Addresses")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("AddressesId");

            builder.Property(p => p.Address1)
                .HasMaxLength(500);

            builder.Property(p => p.Address2)
                .HasMaxLength(500);

            builder.Property(p => p.Number)
                .HasMaxLength(10);
            
            builder.Property(p => p.City)
                .HasMaxLength(100);

            builder.Property(p => p.State)
                .HasMaxLength(100);

            builder.Property(p => p.PostalCode)
                .HasMaxLength(10);

            base.Configure(builder);
        }
    }
}

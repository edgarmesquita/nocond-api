using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Person.Data;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Meeting.Configurations
{
    internal class PersonConfiguration : AuditMetadataConfiguration<PersonData>
    {
        public override void Configure(EntityTypeBuilder<PersonData> builder)
        {
            builder
                .ToTable("Persons")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("PersonId");

            builder.Property(p => p.UserId)
                .IsRequired(false);

            builder.Property(p => p.Name)
                .HasMaxLength(200);

            builder.Property(p => p.Email)
                .HasMaxLength(200);

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(p => p.MobilePhoneNumber)
                .HasMaxLength(20);

            builder.Property(p => p.Nickname)
                .HasMaxLength(100);

            builder.Property(p => p.IdNumber)
                .HasMaxLength(50);

            builder.Property(p => p.TaxNumber)
                .HasMaxLength(50);

            builder.HasIndex(p => p.IdNumber)
                .IsUnique()
                .HasFilter(null);

            builder.HasIndex(p => p.TaxNumber)
                .IsUnique()
                .HasFilter(null);

            base.Configure(builder);
        }
    }
}
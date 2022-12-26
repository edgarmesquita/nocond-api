using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Person.Data;

namespace NoCond.Persistence.Meeting.Configurations
{
    internal class PersonAddressConfiguration : IEntityTypeConfiguration<PersonAdressesData>
    {
        public void Configure(EntityTypeBuilder<PersonAdressesData> builder)
        {
            builder
               .ToTable("PersonAddresses")
               .HasKey(x => new { x.PersonId, x.AddressId });

            builder.HasOne(x => x.Person)
                .WithMany(x => x.WithAddresses)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(x => x.Address)
                .WithMany(x => x.WithPersons)
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}

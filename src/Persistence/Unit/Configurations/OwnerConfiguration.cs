using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Unit.Data;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Unit.Configurations
{
    internal class OwnerConfiguration : AuditMetadataConfiguration<OwnerData>
    {
        public override void Configure(EntityTypeBuilder<OwnerData> builder)
        {
            builder
                .ToTable("Owners")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("OwnerId");

            builder.Property(p => p.UnitId);

            builder.Property(p => p.PersonId);

            builder.Property(p => p.OwnerTypeId);

            builder.HasOne(p => p.Type)
                .WithMany(p => p.Owners)
                .HasForeignKey(p => p.OwnerTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Person)
                .WithMany(p => p.Owners)
                .HasForeignKey(p => p.PersonId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Unit)
                .WithMany(p => p.Owners)
                .HasForeignKey(p => p.UnitId)
                .OnDelete(DeleteBehavior.NoAction);
            
            base.Configure(builder);
        }
    }
}
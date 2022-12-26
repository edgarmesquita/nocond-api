using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Unit.Data;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Unit.Configurations
{
    internal class UnitGroupConfiguration : AuditMetadataConfiguration<UnitGroupData>
    {
        public override void Configure(EntityTypeBuilder<UnitGroupData> builder)
        {
            builder
                .ToTable("UnitGroups")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("UnitGroupId");

            builder.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();
            
            base.Configure(builder);
        }
    }
}
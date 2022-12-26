using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Unit.Data;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Unit.Configurations
{
    internal class UnitConfiguration : AuditMetadataConfiguration<UnitData>
    {
        public override void Configure(EntityTypeBuilder<UnitData> builder)
        {
            builder
                .ToTable("Units")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("UnitId");

            builder.Property(p => p.UnitTypeId)
                .HasColumnName("UnitTypeId");

            builder.Property(p => p.Block)
                .HasMaxLength(10);

            builder.Property(p => p.BlockDescription)
                .HasMaxLength(200);
            
            builder.Property(p => p.Code)
                .HasMaxLength(10);
            
            builder.Property(p => p.CodePrefix)
                .HasMaxLength(10);
            
            builder.Property(p => p.CodeSuffix)
                .HasMaxLength(10);
            
            builder.Property(p => p.Side)
                .HasMaxLength(10);
            
            builder.HasOne(p => p.Type)
                .WithMany(p => p.Units)
                .HasForeignKey(p => p.UnitTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.UnitGroup)
                .WithMany(p => p.Units)
                .HasForeignKey(p => p.UnitGroupId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
            
            base.Configure(builder);
        }
    }
}
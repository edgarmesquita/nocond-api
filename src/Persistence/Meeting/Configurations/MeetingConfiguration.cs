using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Meeting.Data;
using NoCond.Application.Meeting.Models;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Meeting.Configurations
{
    internal class MeetingConfiguration : AuditMetadataConfiguration<MeetingData>
    {
        public override void Configure(EntityTypeBuilder<MeetingData> builder)
        {
            builder
                .ToTable("Meetings")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("MeetingId")
                .IsRequired();

            builder.Property(p => p.MeetingTypeId)
                .HasColumnName("MeetingTypeId")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("Name");

            builder.Property(p => p.Description)
                .HasColumnName("Description");

            builder.Property(p => p.StartsOn)
                .HasColumnName("StartsOn");

            builder.Property(p => p.EndsOn)
                .HasColumnName("EndsOn");

            builder.Property(p => p.StatusCode)
                .HasColumnName("StatusCode")
                .HasDefaultValue(MeetingStatus.Created)
                .IsRequired();
            
            builder.HasOne(p => p.UnitGroup)
                .WithMany(p => p.Meetings)
                .HasForeignKey(p => p.UnitGroupId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(true);

            builder.HasOne(p => p.Type)
                .WithMany(p => p.Meetings)
                .HasForeignKey(p => p.MeetingTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            base.Configure(builder);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Meeting.Data;

namespace NoCond.Persistence.Meeting.Configurations
{
    internal class MeetingUnitConfiguration : IEntityTypeConfiguration<MeetingUnitData>
    {
        public void Configure(EntityTypeBuilder<MeetingUnitData> builder)
        {
            builder
                .ToTable("MeetingUnits")
                .HasKey(x => new { x.MeetingId, x.UnitId });

            builder.HasOne(x => x.Meeting)
                .WithMany(x => x.WithUnits)
                .HasForeignKey(x => x.MeetingId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(x => x.Unit)
                .WithMany(x => x.WithMeetings)
                .HasForeignKey(x => x.UnitId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
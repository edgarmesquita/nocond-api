using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Meeting.Data;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Meeting.Configurations
{
    internal class VotingSessionConfiguration : AuditMetadataConfiguration<VotingSessionData>
    {
        public override void Configure(EntityTypeBuilder<VotingSessionData> builder)
        {
            builder
                .ToTable("VotingSessions")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("VotingSessionId");

            builder.Property(p => p.MeetingId);

            builder.Property(p => p.Description)
                .IsRequired(false);
            
            builder.Property(p => p.Order)
                .IsRequired(true)
                .HasDefaultValue(0);
            
            builder.Property(p => p.StartsOn);

            builder.Property(p => p.EndsOn);

            builder.Property(p => p.StatusCode);

            builder.HasOne(p => p.Meeting)
                .WithMany(p => p.VotingSessions)
                .HasForeignKey(p => p.MeetingId)
                .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
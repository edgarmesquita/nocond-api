using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Meeting.Data;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Meeting.Configurations
{
    internal class VotingTopicConfiguration : AuditMetadataConfiguration<VotingTopicData>
    {
        public override void Configure(EntityTypeBuilder<VotingTopicData> builder)
        {
            builder
                .ToTable("VotingTopics")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("VotingTopicId");

            builder.Property(p => p.VotingSessionId)
                .HasColumnName("VotingSessionId");

            builder.Property(p => p.Text)
                .HasColumnName("Text");

            builder.Property(p => p.Introdution)
                .HasColumnName("Introdution");

            builder.Property(p => p.AnswerLimit)
                .HasColumnName("AnswerLimit");

            builder.Property(p => p.Order)
                .HasColumnName("Order");

            builder.Property(p => p.Duration)
                .HasColumnName("Duration");

            builder.HasOne(p => p.VotingSession)
                .WithMany(p => p.VotingTopics)
                .HasForeignKey(p => p.VotingSessionId)
                .OnDelete(DeleteBehavior.NoAction);

            base.Configure(builder);
        }
    }
}
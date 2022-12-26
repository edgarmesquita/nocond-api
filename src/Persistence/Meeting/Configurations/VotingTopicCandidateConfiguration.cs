using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Meeting.Data;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Meeting.Configurations
{
    internal class VotingTopicCandidateConfiguration: HistoryMetadataConfiguration<VotingTopicCandidateData>
    {
        public override void Configure(EntityTypeBuilder<VotingTopicCandidateData> builder)
        {
            builder
                .ToTable("VotingTopicCandidates")
                .HasKey(x => new { x.VotingTopicId, x.PersonId });

            builder.HasOne(x => x.VotingTopic)
                .WithMany(x => x.WithCandidates)
                .HasForeignKey(x => x.VotingTopicId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(x => x.Person)
                .WithMany(x => x.WithCandidates)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            
            base.Configure(builder);
        }
    }
}
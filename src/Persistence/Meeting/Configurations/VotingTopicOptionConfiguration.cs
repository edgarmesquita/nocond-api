using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Meeting.Data;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Meeting.Configurations
{
    internal class VotingTopicOptionConfiguration : AuditMetadataConfiguration<VotingTopicOptionData>
    {
        public override void Configure(EntityTypeBuilder<VotingTopicOptionData> builder)
        {
            builder
                .ToTable("VotingTopicOptions")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("VotingTopicOptionId");

            builder.Property(p => p.VotingTopicId)
                .HasColumnName("VotingTopicId");

            builder.Property(p => p.TypeCode)
                .HasColumnName("TypeCode");

            builder.Property(p => p.Label)
                .HasColumnName("Label");

            builder.Property(p => p.IsFillableOption)
                .HasColumnName("IsFillableOption");

            builder.Property(p => p.Editable)
                .HasColumnName("Editable");

            builder.HasOne(p => p.VotingTopic)
                .WithMany(p => p.VotingTopicOptions)
                .HasForeignKey(p => p.VotingTopicId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Person)
                .WithMany(p => p.VotingTopicOptions)
                .HasForeignKey(p => p.VotingTopicId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            base.Configure(builder);
        }
    }
}
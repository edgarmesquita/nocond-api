using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Meeting.Data;

namespace NoCond.Persistence.Meeting.Configurations
{
    public class MeetingDocumentConfiguration  : IEntityTypeConfiguration<MeetingDocumentData>
    {
        public void Configure(EntityTypeBuilder<MeetingDocumentData> builder)
        {
            builder
                .ToTable("MeetingDocuments")
                .HasKey(x => new { x.MeetingId, x.DocumentId });

            builder.HasOne(x => x.Meeting)
                .WithMany(x => x.WithDocuments)
                .HasForeignKey(x => x.MeetingId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(x => x.Document)
                .WithMany(x => x.WithMeetings)
                .HasForeignKey(x => x.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
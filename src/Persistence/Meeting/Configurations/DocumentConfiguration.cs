using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Meeting.Data;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Meeting.Configurations
{
    internal class DocumentConfiguration : AuditMetadataConfiguration<DocumentData>
    {
        public override void Configure(EntityTypeBuilder<DocumentData> builder)
        {
            builder
                .ToTable("Documents")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("DocumentId");

            builder.Property(p => p.Path)
                .HasColumnName("Path");

            base.Configure(builder);
        }
    }
}
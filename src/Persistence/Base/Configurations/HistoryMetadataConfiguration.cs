using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Base.Models;

namespace NoCond.Persistence.Base.Configurations
{
    internal class HistoryMetadataConfiguration<TEntity> : AuditMetadataConfiguration<TEntity> where TEntity : HistoryMetadata
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.EndedById)
                .IsRequired(false);

            builder.Property(x => x.EndedOn)
                .IsRequired(false);
        }
    }
}
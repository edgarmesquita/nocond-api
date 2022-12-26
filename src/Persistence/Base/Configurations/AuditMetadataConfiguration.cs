using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Base.Models;

namespace NoCond.Persistence.Base.Configurations
{
    [ExcludeFromCodeCoverage]
    internal abstract class AuditMetadataConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : AuditMetadata
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.CreatedById)
                .IsRequired(false);

            builder.Property(x => x.CreatedOn)
                .IsRequired();

            builder.Property(x => x.LastUpdatedById)
                .IsRequired(false);

            builder.Property(x => x.LastUpdatedOn)
                .IsRequired(false);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Email.Data;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Email.Configurations
{
    internal class EmailTemplateConfiguration : AuditMetadataConfiguration<EmailTemplateData>
    {
        public override void Configure(EntityTypeBuilder<EmailTemplateData> builder)
        {
            builder
                .ToTable("EmailTemplates")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("EmailTemplateId");

            builder.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Code)
                .HasMaxLength(50)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Settings.Data;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Settings.Configurations
{
    internal class MeetingSettingsConfiguration : HistoryMetadataConfiguration<MeetingSettingsData>
    {
        public override void Configure(EntityTypeBuilder<MeetingSettingsData> builder)
        {
            builder
                .ToTable("MeetingSettings")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("MeetingSettingsId");

            builder.HasOne(x => x.BeforeNotificationEmailTemplate)
                .WithMany()
                .HasForeignKey(x => x.BeforeNotificationEmailTemplateId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.CreationEmailTemplate)
                .WithMany()
                .HasForeignKey(x => x.CreationEmailTemplateId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
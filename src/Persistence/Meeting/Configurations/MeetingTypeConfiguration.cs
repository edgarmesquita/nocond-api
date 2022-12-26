using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Meeting.Data;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Meeting.Configurations
{
    internal class MeetingTypeConfiguration : AuditMetadataConfiguration<MeetingTypeData>
    {
        public override void Configure(EntityTypeBuilder<MeetingTypeData> builder)
        {
            builder
                .ToTable("MeetingTypes")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("MeetingTypeId")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired(false);
            
            base.Configure(builder);

            builder.HasData(new[]
            {
                new MeetingTypeData
                {
                    Id = new Guid("ECF6C4F9-F7C4-4B4C-97D6-D52A7EB3E9A5"),
                    Name = "AGE",
                    Description = "Assembleia Geral Extraordinária",
                    CreatedOn = new DateTime(2020, 10, 25)
                },
                new MeetingTypeData
                {
                    Id = new Guid("4514A178-A1A3-4686-A338-8735303C6693"),
                    Name = "AGI",
                    Description = "Assembleia Geral de Instalação",
                    CreatedOn = new DateTime(2020, 10, 25)
                },
                new MeetingTypeData
                {
                    Id = new Guid("D09C8374-1735-4761-AF71-25C8B976729F"),
                    Name = "AGO",
                    Description = "Assembleia Geral Ordinária",
                    CreatedOn = new DateTime(2020, 10, 25)
                }
            });
        }
    }
}
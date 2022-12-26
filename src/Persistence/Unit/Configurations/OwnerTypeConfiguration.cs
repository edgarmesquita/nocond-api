using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Unit.Data;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Unit.Configurations
{
    internal class OwnerTypeConfiguration : AuditMetadataConfiguration<OwnerTypeData>
    {
        public override void Configure(EntityTypeBuilder<OwnerTypeData> builder)
        {
            builder
                .ToTable("OwnerTypes")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("OwnerTypeId");

            builder.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired(false);

            base.Configure(builder);
            
            builder.HasData(new[]
            {
                new OwnerTypeData
                {
                    Id = new Guid("94068131-D678-44CC-A89C-5223E19C6B23"),
                    Name = "Pessoa Física",
                    CreatedOn = new DateTime(2020, 10, 25)
                },
                new OwnerTypeData
                {
                    Id = new Guid("2D2E067C-2FBF-4700-8216-7B07DF29F418"),
                    Name = "Pessoa Jurídica",
                    CreatedOn = new DateTime(2020, 10, 25)
                },
                new OwnerTypeData
                {
                    Id = new Guid("5A6AF403-E037-42B8-BF1D-94B77B385A94"),
                    Name = "Responsável com Procuração",
                    CreatedOn = new DateTime(2020, 10, 25)
                }
            });
        }
    }
}
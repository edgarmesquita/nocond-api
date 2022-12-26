using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCond.Application.Unit.Data;
using NoCond.Persistence.Base.Configurations;

namespace NoCond.Persistence.Unit.Configurations
{
    internal class UnitTypeConfiguration : AuditMetadataConfiguration<UnitTypeData>
    {
        public override void Configure(EntityTypeBuilder<UnitTypeData> builder)
        {
            builder
                .ToTable("UnitTypes")
                .HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .HasColumnName("UnitTypeId");

            builder.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired(false);

            base.Configure(builder);
            
            builder.HasData(new[]
            {
                new UnitTypeData
                {
                    Id = new Guid("8F30816F-0858-4F8E-9E8C-23F96E7BF841"),
                    Name = "Sala",
                    CreatedOn = new DateTime(2020, 10, 25)
                },
                new UnitTypeData
                {
                    Id = new Guid("D2D198F8-C29E-45DD-AC55-468DAD85237E"),
                    Name = "Loja",
                    CreatedOn = new DateTime(2020, 10, 25)
                },
                new UnitTypeData
                {
                    Id = new Guid("69F09BCC-9BB8-4D12-B14F-520E654AFC1C"),
                    Name = "Edícula",
                    CreatedOn = new DateTime(2020, 10, 25)
                },
                new UnitTypeData
                {
                    Id = new Guid("877FA233-EDA2-4ED6-83CD-541CFD103977"),
                    Name = "Box",
                    CreatedOn = new DateTime(2020, 10, 25)
                },
                new UnitTypeData
                {
                    Id = new Guid("EAA67684-5E44-47DF-A8CC-8ECF5AE34418"),
                    Name = "Kiosque",
                    CreatedOn = new DateTime(2020, 10, 25)
                },
                new UnitTypeData
                {
                    Id = new Guid("5194A3E6-B86F-46EF-A645-2AC3238BEC26"),
                    Name = "Apartamento",
                    CreatedOn = new DateTime(2020, 10, 25)
                },
                new UnitTypeData
                {
                    Id = new Guid("B9D567BD-CB55-4E40-89BF-C4032A7A1719"),
                    Name = "Cobertura",
                    CreatedOn = new DateTime(2020, 10, 25)
                },
                new UnitTypeData
                {
                    Id = new Guid("73DF42BF-6781-49A6-948C-4160198A7303"),
                    Name = "Casa",
                    CreatedOn = new DateTime(2020, 10, 25)
                },
                new UnitTypeData
                {
                    Id = new Guid("1A1ECA3D-C606-488B-82D3-AF63653C1124"),
                    Name = "Lote",
                    CreatedOn = new DateTime(2020, 10, 25)
                }
            });
        }
    }
}
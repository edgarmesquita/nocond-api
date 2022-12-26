using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoCond.Persistence.Migrations
{
    public partial class SeedTypesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "UnitTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UnitTypes",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OwnerTypes",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MeetingTypes",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "MeetingTypes",
                columns: new[] { "MeetingTypeId", "CreatedById", "CreatedOn", "Description", "LastUpdatedById", "LastUpdatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("ecf6c4f9-f7c4-4b4c-97d6-d52a7eb3e9a5"), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assembleia Geral Extraordinária", null, null, "AGE" },
                    { new Guid("4514a178-a1a3-4686-a338-8735303c6693"), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assembleia Geral de Instalação", null, null, "AGI" },
                    { new Guid("d09c8374-1735-4761-af71-25c8b976729f"), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assembleia Geral Ordinária", null, null, "AGO" }
                });

            migrationBuilder.InsertData(
                table: "OwnerTypes",
                columns: new[] { "OwnerTypeId", "CreatedById", "CreatedOn", "Description", "LastUpdatedById", "LastUpdatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("94068131-d678-44cc-a89c-5223e19c6b23"), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Pessoa Física" },
                    { new Guid("2d2e067c-2fbf-4700-8216-7b07df29f418"), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Pessoa Jurídica" },
                    { new Guid("5a6af403-e037-42b8-bf1d-94b77b385a94"), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Responsável com Procuração" }
                });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "UnitTypeId", "CreatedById", "CreatedOn", "Description", "LastUpdatedById", "LastUpdatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("8f30816f-0858-4f8e-9e8c-23f96e7bf841"), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Sala" },
                    { new Guid("d2d198f8-c29e-45dd-ac55-468dad85237e"), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Loja" },
                    { new Guid("69f09bcc-9bb8-4d12-b14f-520e654afc1c"), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Edícula" },
                    { new Guid("877fa233-eda2-4ed6-83cd-541cfd103977"), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Box" },
                    { new Guid("eaa67684-5e44-47df-a8cc-8ecf5ae34418"), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Kiosque" },
                    { new Guid("5194a3e6-b86f-46ef-a645-2ac3238bec26"), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Apartamento" },
                    { new Guid("b9d567bd-cb55-4e40-89bf-c4032a7a1719"), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Cobertura" },
                    { new Guid("73df42bf-6781-49a6-948c-4160198a7303"), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Casa" },
                    { new Guid("1a1eca3d-c606-488b-82d3-af63653c1124"), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Lote" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MeetingTypes",
                keyColumn: "MeetingTypeId",
                keyValue: new Guid("4514a178-a1a3-4686-a338-8735303c6693"));

            migrationBuilder.DeleteData(
                table: "MeetingTypes",
                keyColumn: "MeetingTypeId",
                keyValue: new Guid("d09c8374-1735-4761-af71-25c8b976729f"));

            migrationBuilder.DeleteData(
                table: "MeetingTypes",
                keyColumn: "MeetingTypeId",
                keyValue: new Guid("ecf6c4f9-f7c4-4b4c-97d6-d52a7eb3e9a5"));

            migrationBuilder.DeleteData(
                table: "OwnerTypes",
                keyColumn: "OwnerTypeId",
                keyValue: new Guid("2d2e067c-2fbf-4700-8216-7b07df29f418"));

            migrationBuilder.DeleteData(
                table: "OwnerTypes",
                keyColumn: "OwnerTypeId",
                keyValue: new Guid("5a6af403-e037-42b8-bf1d-94b77b385a94"));

            migrationBuilder.DeleteData(
                table: "OwnerTypes",
                keyColumn: "OwnerTypeId",
                keyValue: new Guid("94068131-d678-44cc-a89c-5223e19c6b23"));

            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "UnitTypeId",
                keyValue: new Guid("1a1eca3d-c606-488b-82d3-af63653c1124"));

            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "UnitTypeId",
                keyValue: new Guid("5194a3e6-b86f-46ef-a645-2ac3238bec26"));

            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "UnitTypeId",
                keyValue: new Guid("69f09bcc-9bb8-4d12-b14f-520e654afc1c"));

            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "UnitTypeId",
                keyValue: new Guid("73df42bf-6781-49a6-948c-4160198a7303"));

            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "UnitTypeId",
                keyValue: new Guid("877fa233-eda2-4ed6-83cd-541cfd103977"));

            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "UnitTypeId",
                keyValue: new Guid("8f30816f-0858-4f8e-9e8c-23f96e7bf841"));

            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "UnitTypeId",
                keyValue: new Guid("b9d567bd-cb55-4e40-89bf-c4032a7a1719"));

            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "UnitTypeId",
                keyValue: new Guid("d2d198f8-c29e-45dd-ac55-468dad85237e"));

            migrationBuilder.DeleteData(
                table: "UnitTypes",
                keyColumn: "UnitTypeId",
                keyValue: new Guid("eaa67684-5e44-47df-a8cc-8ecf5ae34418"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UnitTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                table: "UnitTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OwnerTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MeetingTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}

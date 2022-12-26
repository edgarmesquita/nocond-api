using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoCond.Persistence.Migrations
{
    public partial class EmailTemplateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EndedOn",
                table: "VotingSessions",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "EndedById",
                table: "VotingSessions",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndedOn",
                table: "Owners",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "EndedById",
                table: "Owners",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    EmailTemplateId = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<Guid>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.EmailTemplateId);
                });

            migrationBuilder.CreateTable(
                name: "MeetingSettings",
                columns: table => new
                {
                    MeetingSettingsId = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<Guid>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    EndedOn = table.Column<DateTime>(nullable: true),
                    EndedById = table.Column<Guid>(nullable: true),
                    CreationEmailTemplateId = table.Column<Guid>(nullable: false),
                    BeforeNotificationEmailTemplateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingSettings", x => x.MeetingSettingsId);
                    table.ForeignKey(
                        name: "FK_MeetingSettings_EmailTemplates_BeforeNotificationEmailTemplateId",
                        column: x => x.BeforeNotificationEmailTemplateId,
                        principalTable: "EmailTemplates",
                        principalColumn: "EmailTemplateId");
                    table.ForeignKey(
                        name: "FK_MeetingSettings_EmailTemplates_CreationEmailTemplateId",
                        column: x => x.CreationEmailTemplateId,
                        principalTable: "EmailTemplates",
                        principalColumn: "EmailTemplateId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingSettings_BeforeNotificationEmailTemplateId",
                table: "MeetingSettings",
                column: "BeforeNotificationEmailTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingSettings_CreationEmailTemplateId",
                table: "MeetingSettings",
                column: "CreationEmailTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingSettings");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndedOn",
                table: "VotingSessions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EndedById",
                table: "VotingSessions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndedOn",
                table: "Owners",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EndedById",
                table: "Owners",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}

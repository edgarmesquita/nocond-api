using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoCond.Persistence.Migrations
{
    public partial class VotingTopicCandidateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Owners_OwnerId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_OwnerId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "VotingSessions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "VotingSessions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VotingTopicCandidates",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    VotingTopicId = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<Guid>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    EndedOn = table.Column<DateTime>(nullable: true),
                    EndedById = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingTopicCandidates", x => new { x.VotingTopicId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_VotingTopicCandidates_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotingTopicCandidates_VotingTopics_VotingTopicId",
                        column: x => x.VotingTopicId,
                        principalTable: "VotingTopics",
                        principalColumn: "VotingTopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Owners_PersonId",
                table: "Owners",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingTopicCandidates_PersonId",
                table: "VotingTopicCandidates",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Persons_PersonId",
                table: "Owners",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Persons_PersonId",
                table: "Owners");

            migrationBuilder.DropTable(
                name: "VotingTopicCandidates");

            migrationBuilder.DropIndex(
                name: "IX_Owners_PersonId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "VotingSessions");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "VotingSessions");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Persons_OwnerId",
                table: "Persons",
                column: "OwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Owners_OwnerId",
                table: "Persons",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoCond.Persistence.Migrations
{
    public partial class MeetingUnitGroupMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VotingSessions_Meetings_MeetingId",
                table: "VotingSessions");

            migrationBuilder.AddColumn<Guid>(
                name: "UnitGroupId",
                table: "Meetings",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_UnitGroupId",
                table: "Meetings",
                column: "UnitGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_UnitGroups_UnitGroupId",
                table: "Meetings",
                column: "UnitGroupId",
                principalTable: "UnitGroups",
                principalColumn: "UnitGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_VotingSessions_Meetings_MeetingId",
                table: "VotingSessions",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "MeetingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_UnitGroups_UnitGroupId",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_VotingSessions_Meetings_MeetingId",
                table: "VotingSessions");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_UnitGroupId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "UnitGroupId",
                table: "Meetings");

            migrationBuilder.AddForeignKey(
                name: "FK_VotingSessions_Meetings_MeetingId",
                table: "VotingSessions",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "MeetingId");
        }
    }
}

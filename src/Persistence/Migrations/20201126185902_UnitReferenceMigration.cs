using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoCond.Persistence.Migrations
{
    public partial class UnitReferenceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_UnitGroups_UnitGroupDataId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_UnitGroupDataId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UnitGroupDataId",
                table: "Units");

            migrationBuilder.AddColumn<Guid>(
                name: "UnitGroupId",
                table: "Units",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitGroupId",
                table: "Units",
                column: "UnitGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_UnitGroups_UnitGroupId",
                table: "Units",
                column: "UnitGroupId",
                principalTable: "UnitGroups",
                principalColumn: "UnitGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_UnitGroups_UnitGroupId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_UnitGroupId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UnitGroupId",
                table: "Units");

            migrationBuilder.AddColumn<Guid>(
                name: "UnitGroupDataId",
                table: "Units",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitGroupDataId",
                table: "Units",
                column: "UnitGroupDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_UnitGroups_UnitGroupDataId",
                table: "Units",
                column: "UnitGroupDataId",
                principalTable: "UnitGroups",
                principalColumn: "UnitGroupId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

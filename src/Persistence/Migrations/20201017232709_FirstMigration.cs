using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoCond.Persistence.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<Guid>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: false),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<Guid>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "MeetingTypes",
                columns: table => new
                {
                    MeetingTypeId = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<Guid>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingTypes", x => x.MeetingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "OwnerTypes",
                columns: table => new
                {
                    OwnerTypeId = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<Guid>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerTypes", x => x.OwnerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UnitTypes",
                columns: table => new
                {
                    UnitTypeId = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<Guid>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    UnitId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.UnitTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    MeetingId = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<Guid>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MeetingTypeId = table.Column<Guid>(nullable: false),
                    StartsOn = table.Column<DateTime>(nullable: false),
                    EndsOn = table.Column<DateTime>(nullable: false),
                    StatusCode = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.MeetingId);
                    table.ForeignKey(
                        name: "FK_Meetings_MeetingTypes_MeetingTypeId",
                        column: x => x.MeetingTypeId,
                        principalTable: "MeetingTypes",
                        principalColumn: "MeetingTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<Guid>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    Block = table.Column<string>(nullable: true),
                    UnitTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_Units_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "UnitTypeId");
                });

            migrationBuilder.CreateTable(
                name: "MeetingDocuments",
                columns: table => new
                {
                    MeetingId = table.Column<Guid>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingDocuments", x => new { x.MeetingId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_MeetingDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingDocuments_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VotingSessions",
                columns: table => new
                {
                    VotingSessionId = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<Guid>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    EndedOn = table.Column<DateTime>(nullable: false),
                    EndedById = table.Column<Guid>(nullable: false),
                    MeetingId = table.Column<Guid>(nullable: false),
                    StatusCode = table.Column<int>(nullable: false),
                    StartsOn = table.Column<DateTime>(nullable: false),
                    EndsOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingSessions", x => x.VotingSessionId);
                    table.ForeignKey(
                        name: "FK_VotingSessions_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "MeetingId");
                });

            migrationBuilder.CreateTable(
                name: "MeetingUnits",
                columns: table => new
                {
                    MeetingId = table.Column<Guid>(nullable: false),
                    UnitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingUnits", x => new { x.MeetingId, x.UnitId });
                    table.ForeignKey(
                        name: "FK_MeetingUnits_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingUnits_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<Guid>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    EndedOn = table.Column<DateTime>(nullable: false),
                    EndedById = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false),
                    UnitId = table.Column<Guid>(nullable: false),
                    OwnerTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Owners_OwnerTypes_OwnerTypeId",
                        column: x => x.OwnerTypeId,
                        principalTable: "OwnerTypes",
                        principalColumn: "OwnerTypeId");
                    table.ForeignKey(
                        name: "FK_Owners_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId");
                });

            migrationBuilder.CreateTable(
                name: "VotingTopics",
                columns: table => new
                {
                    VotingTopicId = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<Guid>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    VotingSessionId = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Introdution = table.Column<string>(nullable: true),
                    AnswerLimit = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingTopics", x => x.VotingTopicId);
                    table.ForeignKey(
                        name: "FK_VotingTopics_VotingSessions_VotingSessionId",
                        column: x => x.VotingSessionId,
                        principalTable: "VotingSessions",
                        principalColumn: "VotingSessionId");
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<Guid>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    MobilePhoneNumber = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(nullable: true),
                    TaxNumber = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_AddressData_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persons_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId");
                });

            migrationBuilder.CreateTable(
                name: "VotingTopicOptions",
                columns: table => new
                {
                    VotingTopicOptionId = table.Column<Guid>(nullable: false),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<Guid>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    VotingTopicId = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false),
                    TypeCode = table.Column<int>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Editable = table.Column<bool>(nullable: false),
                    IsFillableOption = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingTopicOptions", x => x.VotingTopicOptionId);
                    table.ForeignKey(
                        name: "FK_VotingTopicOptions_Persons_VotingTopicId",
                        column: x => x.VotingTopicId,
                        principalTable: "Persons",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_VotingTopicOptions_VotingTopics_VotingTopicId",
                        column: x => x.VotingTopicId,
                        principalTable: "VotingTopics",
                        principalColumn: "VotingTopicId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingDocuments_DocumentId",
                table: "MeetingDocuments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_MeetingTypeId",
                table: "Meetings",
                column: "MeetingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingUnits_UnitId",
                table: "MeetingUnits",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_OwnerTypeId",
                table: "Owners",
                column: "OwnerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_UnitId",
                table: "Owners",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AddressId",
                table: "Persons",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IdNumber",
                table: "Persons",
                column: "IdNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_OwnerId",
                table: "Persons",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TaxNumber",
                table: "Persons",
                column: "TaxNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitTypeId",
                table: "Units",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingSessions_MeetingId",
                table: "VotingSessions",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingTopicOptions_VotingTopicId",
                table: "VotingTopicOptions",
                column: "VotingTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingTopics_VotingSessionId",
                table: "VotingTopics",
                column: "VotingSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingDocuments");

            migrationBuilder.DropTable(
                name: "MeetingUnits");

            migrationBuilder.DropTable(
                name: "VotingTopicOptions");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "VotingTopics");

            migrationBuilder.DropTable(
                name: "AddressData");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "VotingSessions");

            migrationBuilder.DropTable(
                name: "OwnerTypes");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "UnitTypes");

            migrationBuilder.DropTable(
                name: "MeetingTypes");
        }
    }
}

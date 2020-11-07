using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkAssistantApp.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusEventType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusEventType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusStartHour",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hour = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusStartHour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    ProjectManagerId = table.Column<long>(nullable: true),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedById = table.Column<long>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Users_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StatusCurrents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    ProjectId = table.Column<long>(nullable: true),
                    StatusDescription = table.Column<string>(nullable: true),
                    StatusAvailableUse = table.Column<bool>(nullable: false),
                    StatusAvailableFrom = table.Column<DateTime>(nullable: true),
                    StatusAvailableTo = table.Column<DateTime>(nullable: true),
                    StartHourOnMondayId = table.Column<int>(nullable: false),
                    StartHourOnTuesdayId = table.Column<int>(nullable: false),
                    StartHourOnWednesdayId = table.Column<int>(nullable: false),
                    StartHourOnThursdayId = table.Column<int>(nullable: false),
                    StartHourOnFridayId = table.Column<int>(nullable: false),
                    ModifiedById = table.Column<long>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCurrents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusCurrents_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusCurrents_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusCurrents_StatusStartHour_StartHourOnFridayId",
                        column: x => x.StartHourOnFridayId,
                        principalTable: "StatusStartHour",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusCurrents_StatusStartHour_StartHourOnMondayId",
                        column: x => x.StartHourOnMondayId,
                        principalTable: "StatusStartHour",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusCurrents_StatusStartHour_StartHourOnThursdayId",
                        column: x => x.StartHourOnThursdayId,
                        principalTable: "StatusStartHour",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusCurrents_StatusStartHour_StartHourOnTuesdayId",
                        column: x => x.StartHourOnTuesdayId,
                        principalTable: "StatusStartHour",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusCurrents_StatusStartHour_StartHourOnWednesdayId",
                        column: x => x.StartHourOnWednesdayId,
                        principalTable: "StatusStartHour",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusCurrents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusEvents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedById = table.Column<long>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusEvents_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusEvents_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusEvents_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusEvents_StatusEventType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "StatusEventType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatusEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatedById",
                table: "Projects",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ModifiedById",
                table: "Projects",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusCurrents_ModifiedById",
                table: "StatusCurrents",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StatusCurrents_ProjectId",
                table: "StatusCurrents",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusCurrents_StartHourOnFridayId",
                table: "StatusCurrents",
                column: "StartHourOnFridayId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusCurrents_StartHourOnMondayId",
                table: "StatusCurrents",
                column: "StartHourOnMondayId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusCurrents_StartHourOnThursdayId",
                table: "StatusCurrents",
                column: "StartHourOnThursdayId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusCurrents_StartHourOnTuesdayId",
                table: "StatusCurrents",
                column: "StartHourOnTuesdayId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusCurrents_StartHourOnWednesdayId",
                table: "StatusCurrents",
                column: "StartHourOnWednesdayId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusCurrents_UserId",
                table: "StatusCurrents",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusEvents_CreatedById",
                table: "StatusEvents",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StatusEvents_ModifiedById",
                table: "StatusEvents",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StatusEvents_ProjectId",
                table: "StatusEvents",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusEvents_TypeId",
                table: "StatusEvents",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusEvents_UserId",
                table: "StatusEvents",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatusCurrents");

            migrationBuilder.DropTable(
                name: "StatusEvents");

            migrationBuilder.DropTable(
                name: "StatusStartHour");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "StatusEventType");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

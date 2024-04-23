using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USync.Infrastructure.Data.ApplicationDB.Migrations
{
    /// <inheritdoc />
    public partial class DB_v0002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_ProfileRules_ProfileRuleId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileRules_Profile_ProfileId",
                table: "ProfileRules");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profile_ProfileId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "Profiles");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_ProfileRuleId",
                table: "Profiles",
                newName: "IX_Profiles_ProfileRuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Streat = table.Column<string>(type: "TEXT", nullable: false),
                    ZipCode = table.Column<int>(type: "INTEGER", nullable: false),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    LastUserAlteration = table.Column<long>(type: "INTEGER", nullable: false),
                    LastUserAlterationDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ScheduleDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false),
                    LastUserAlteration = table.Column<long>(type: "INTEGER", nullable: false),
                    LastUserAlterationDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserCalendar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    AdressId = table.Column<long>(type: "INTEGER", nullable: false),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false),
                    LastUserAlteration = table.Column<long>(type: "INTEGER", nullable: false),
                    LastUserAlterationDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCalendar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCalendar_Adress_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserCalendar_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: false),
                    UserCalendarId = table.Column<long>(type: "INTEGER", nullable: true),
                    UserTaskId = table.Column<long>(type: "INTEGER", nullable: true),
                    LastUserAlteration = table.Column<long>(type: "INTEGER", nullable: false),
                    LastUserAlterationDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_UserCalendar_UserCalendarId",
                        column: x => x.UserCalendarId,
                        principalTable: "UserCalendar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Person_UserTasks_UserTaskId",
                        column: x => x.UserTaskId,
                        principalTable: "UserTasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_UserCalendarId",
                table: "Person",
                column: "UserCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_UserTaskId",
                table: "Person",
                column: "UserTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCalendar_AdressId",
                table: "UserCalendar",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCalendar_UserId",
                table: "UserCalendar",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_UserId",
                table: "UserTasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileRules_Profiles_ProfileId",
                table: "ProfileRules",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_ProfileRules_ProfileRuleId",
                table: "Profiles",
                column: "ProfileRuleId",
                principalTable: "ProfileRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileRules_Profiles_ProfileId",
                table: "ProfileRules");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_ProfileRules_ProfileRuleId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "UserCalendar");

            migrationBuilder.DropTable(
                name: "UserTasks");

            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "Profile");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_ProfileRuleId",
                table: "Profile",
                newName: "IX_Profile_ProfileRuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile",
                table: "Profile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_ProfileRules_ProfileRuleId",
                table: "Profile",
                column: "ProfileRuleId",
                principalTable: "ProfileRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileRules_Profile_ProfileId",
                table: "ProfileRules",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profile_ProfileId",
                table: "Users",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}

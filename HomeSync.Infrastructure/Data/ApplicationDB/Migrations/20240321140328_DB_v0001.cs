using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeSync.Infrastructure.Data.ApplicationDB.Migrations
{
    /// <inheritdoc />
    public partial class DB_v0001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ProfileRuleId = table.Column<long>(type: "INTEGER", nullable: false),
                    LastUserAlteration = table.Column<long>(type: "INTEGER", nullable: false),
                    LastUserAlterationDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileRules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ProfileId = table.Column<long>(type: "INTEGER", nullable: true),
                    LastUserAlteration = table.Column<long>(type: "INTEGER", nullable: false),
                    LastUserAlterationDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileRules_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    ProfileId = table.Column<long>(type: "INTEGER", nullable: false),
                    LastUserAlteration = table.Column<long>(type: "INTEGER", nullable: false),
                    LastUserAlterationDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profile_ProfileRuleId",
                table: "Profile",
                column: "ProfileRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileRules_ProfileId",
                table: "ProfileRules",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileId",
                table: "Users",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_ProfileRules_ProfileRuleId",
                table: "Profile",
                column: "ProfileRuleId",
                principalTable: "ProfileRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_ProfileRules_ProfileRuleId",
                table: "Profile");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProfileRules");

            migrationBuilder.DropTable(
                name: "Profile");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USync.Infrastructure.Data.ApplicationDB.Migrations
{
    /// <inheritdoc />
    public partial class DB_v0004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_UserCalendar_UserCalendarId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCalendar_Adress_AdressId",
                table: "UserCalendar");

            migrationBuilder.RenameColumn(
                name: "UserCalendarId",
                table: "Person",
                newName: "UserCalendarEventId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_UserCalendarId",
                table: "Person",
                newName: "IX_Person_UserCalendarEventId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserTasks",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "AdressId",
                table: "UserCalendar",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_UserCalendar_UserCalendarEventId",
                table: "Person",
                column: "UserCalendarEventId",
                principalTable: "UserCalendar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCalendar_Adress_AdressId",
                table: "UserCalendar",
                column: "AdressId",
                principalTable: "Adress",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_UserCalendar_UserCalendarEventId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCalendar_Adress_AdressId",
                table: "UserCalendar");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserTasks");

            migrationBuilder.RenameColumn(
                name: "UserCalendarEventId",
                table: "Person",
                newName: "UserCalendarId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_UserCalendarEventId",
                table: "Person",
                newName: "IX_Person_UserCalendarId");

            migrationBuilder.AlterColumn<long>(
                name: "AdressId",
                table: "UserCalendar",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_UserCalendar_UserCalendarId",
                table: "Person",
                column: "UserCalendarId",
                principalTable: "UserCalendar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCalendar_Adress_AdressId",
                table: "UserCalendar",
                column: "AdressId",
                principalTable: "Adress",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}

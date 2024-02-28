using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    public partial class changeUserLogHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoginAt",
                table: "UserLoginHistories",
                newName: "LogDate");

            migrationBuilder.AddColumn<int>(
                name: "HistoryType",
                table: "UserLoginHistories",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HistoryType",
                table: "UserLoginHistories");

            migrationBuilder.RenameColumn(
                name: "LogDate",
                table: "UserLoginHistories",
                newName: "LoginAt");
        }
    }
}

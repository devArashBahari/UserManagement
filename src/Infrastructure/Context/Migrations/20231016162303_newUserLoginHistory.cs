using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Context.Migrations
{
    public partial class newUserLoginHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginHistories_Users_UserFk",
                table: "UserLoginHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserLoginHistories_UserFk",
                table: "UserLoginHistories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserLoginHistories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserLoginHistories");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UserLoginHistories");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserLoginHistories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "CustomerNumber",
                table: "UserLoginHistories",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerNumber",
                table: "UserLoginHistories");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "UserLoginHistories",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserLoginHistories",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserLoginHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserLoginHistories",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginHistories_UserFk",
                table: "UserLoginHistories",
                column: "UserFk");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginHistories_Users_UserFk",
                table: "UserLoginHistories",
                column: "UserFk",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

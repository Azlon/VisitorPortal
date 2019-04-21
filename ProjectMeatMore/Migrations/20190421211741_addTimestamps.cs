using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMeatMore.Migrations
{
    public partial class addTimestamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "UserInfo",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserInfo",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OnCreated",
                table: "UserInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OnEdited",
                table: "UserInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnCreated",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "OnEdited",
                table: "UserInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "UserInfo",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserInfo",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}

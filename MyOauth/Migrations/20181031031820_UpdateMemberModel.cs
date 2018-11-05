using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyOauth.Migrations
{
    public partial class UpdateMemberModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Members",
                newName: "Salt");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Members",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Members",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirtName",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Members",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Members",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Members",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "FirtName",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "Members",
                newName: "Name");
        }
    }
}

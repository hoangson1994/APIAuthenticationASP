using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyOauth.Migrations
{
    public partial class UpdateCredential : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Credentials",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "CreatedTimeMLS",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "ExpiredTimeMLS",
                table: "Credentials");

            migrationBuilder.RenameColumn(
                name: "SecretToken",
                table: "Credentials",
                newName: "RefreshToken");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Credentials",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "Credentials",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Credentials",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CredentialScope",
                table: "Credentials",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredAt",
                table: "Credentials",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Credentials",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Credentials",
                table: "Credentials",
                column: "Token");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Credentials",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "CredentialScope",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "ExpiredAt",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Credentials");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "Credentials",
                newName: "SecretToken");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Credentials",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<long>(
                name: "ID",
                table: "Credentials",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "CreatedTimeMLS",
                table: "Credentials",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ExpiredTimeMLS",
                table: "Credentials",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Credentials",
                table: "Credentials",
                column: "ID");
        }
    }
}

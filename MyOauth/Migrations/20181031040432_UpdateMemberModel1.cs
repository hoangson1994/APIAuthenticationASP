using Microsoft.EntityFrameworkCore.Migrations;

namespace MyOauth.Migrations
{
    public partial class UpdateMemberModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirtName",
                table: "Members",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Members",
                newName: "FirtName");
        }
    }
}

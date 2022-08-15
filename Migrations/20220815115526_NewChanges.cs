using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDBGuiApplication.Migrations
{
    public partial class NewChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "categories",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categories",
                newName: "ID");
        }
    }
}

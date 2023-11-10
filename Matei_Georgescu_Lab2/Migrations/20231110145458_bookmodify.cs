using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Matei_Georgescu_Lab2.Migrations
{
    public partial class bookmodify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorFirstName",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorLastName",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Author",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Author",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "AuthorFirstName",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AuthorLastName",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

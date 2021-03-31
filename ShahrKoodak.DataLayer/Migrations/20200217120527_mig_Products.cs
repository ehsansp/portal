using Microsoft.EntityFrameworkCore.Migrations;

namespace ShahrKoodak.DataLayer.Migrations
{
    public partial class mig_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Darsad",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Erae",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mogheiat",
                table: "Product",
                maxLength: 450,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Darsad",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Erae",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Mogheiat",
                table: "Product");
        }
    }
}

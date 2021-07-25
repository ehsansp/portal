using Microsoft.EntityFrameworkCore.Migrations;

namespace ShahrKoodak.DataLayer.Migrations
{
    public partial class mig_ExtraImageForAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImageName1",
                table: "Product",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductImageName2",
                table: "Product",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductImageName3",
                table: "Product",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductImageName4",
                table: "Product",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductImageName5",
                table: "Product",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductImageName6",
                table: "Product",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageName1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductImageName2",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductImageName3",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductImageName4",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductImageName5",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductImageName6",
                table: "Product");
        }
    }
}

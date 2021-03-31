using Microsoft.EntityFrameworkCore.Migrations;

namespace ShahrKoodak.DataLayer.Migrations
{
    public partial class mig_Vizhegi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vazn",
                table: "Product",
                newName: "Service");

            migrationBuilder.RenameColumn(
                name: "VGA",
                table: "Product",
                newName: "Neshani");

            migrationBuilder.RenameColumn(
                name: "CPU",
                table: "Product",
                newName: "Mohlat");

            migrationBuilder.RenameColumn(
                name: "Abad",
                table: "Product",
                newName: "Estefade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Service",
                table: "Product",
                newName: "Vazn");

            migrationBuilder.RenameColumn(
                name: "Neshani",
                table: "Product",
                newName: "VGA");

            migrationBuilder.RenameColumn(
                name: "Mohlat",
                table: "Product",
                newName: "CPU");

            migrationBuilder.RenameColumn(
                name: "Estefade",
                table: "Product",
                newName: "Abad");
        }
    }
}

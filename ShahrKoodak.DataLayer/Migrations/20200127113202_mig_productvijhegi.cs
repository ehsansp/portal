using Microsoft.EntityFrameworkCore.Migrations;

namespace ShahrKoodak.DataLayer.Migrations
{
    public partial class mig_productvijhegi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Karbord",
                table: "Product",
                newName: "VGA");

            migrationBuilder.RenameColumn(
                name: "Estefade",
                table: "Product",
                newName: "Software");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Product",
                newName: "Selfi");

            migrationBuilder.AddColumn<string>(
                name: "Battery",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatteryProp",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bluetuth",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPU",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Camera",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CameraAblity",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Card",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExMemory",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Farsi",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Felash",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Film",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Focus",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memory",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonitorSize",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Network",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetworkPort",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OS",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OSVersion",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ram",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resolution",
                table: "Product",
                maxLength: 450,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Battery",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BatteryProp",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Bluetuth",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CPU",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Camera",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CameraAblity",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Card",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ExMemory",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Farsi",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Felash",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Film",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Focus",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Memory",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MonitorSize",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Network",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "NetworkPort",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OS",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OSVersion",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Resolution",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "VGA",
                table: "Product",
                newName: "Karbord");

            migrationBuilder.RenameColumn(
                name: "Software",
                table: "Product",
                newName: "Estefade");

            migrationBuilder.RenameColumn(
                name: "Selfi",
                table: "Product",
                newName: "Age");
        }
    }
}

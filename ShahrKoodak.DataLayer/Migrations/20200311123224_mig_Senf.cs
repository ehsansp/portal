using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalBuilder.DataLayer.Migrations
{
    public partial class mig_Senf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Camera",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CameraAblity",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Card",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Darsad",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Erae",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Estefade",
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
                name: "Mogheiat",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Mohlat",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MonitorSize",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Neshani",
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
                name: "ProductPrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Resolution",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Selfi",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Service",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Software",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductPrice2",
                table: "Product",
                newName: "StarNumber");

            migrationBuilder.AddColumn<string>(
                name: "Mantaghe",
                table: "Product",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Product",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductTitle2",
                table: "Product",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductTitle3",
                table: "Product",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tel1",
                table: "Product",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tel2",
                table: "Product",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tel3",
                table: "Product",
                maxLength: 450,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mantaghe",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductTitle2",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductTitle3",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Tel1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Tel2",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Tel3",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "StarNumber",
                table: "Product",
                newName: "ProductPrice2");

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
                name: "Color",
                table: "Product",
                maxLength: 450,
                nullable: true);

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
                name: "Estefade",
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
                name: "Mogheiat",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mohlat",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonitorSize",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Neshani",
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

            migrationBuilder.AddColumn<int>(
                name: "ProductPrice",
                table: "Product",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<string>(
                name: "Selfi",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Service",
                table: "Product",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Software",
                table: "Product",
                maxLength: 450,
                nullable: true);
        }
    }
}

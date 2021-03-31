using Microsoft.EntityFrameworkCore.Migrations;

namespace ShahrKoodak.DataLayer.Migrations
{
    public partial class mig_isShowMobile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShowTel",
                table: "Product",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShowTel",
                table: "Product");
        }
    }
}

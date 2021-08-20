using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalBuilder.DataLayer.Migrations
{
    public partial class mig_AddBitcoinToWallet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "btc",
                table: "Wallets",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "doge",
                table: "Wallets",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "eth",
                table: "Wallets",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "btc",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "doge",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "eth",
                table: "Wallets");
        }
    }
}

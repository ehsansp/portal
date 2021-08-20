using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalBuilder.DataLayer.Migrations
{
    public partial class mig_CurrencyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Currencies",
                newName: "CurrencyId");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Withdrawals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Withdrawals_CurrencyId",
                table: "Withdrawals",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Withdrawals_Currencies_CurrencyId",
                table: "Withdrawals",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Withdrawals_Currencies_CurrencyId",
                table: "Withdrawals");

            migrationBuilder.DropIndex(
                name: "IX_Withdrawals_CurrencyId",
                table: "Withdrawals");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Withdrawals");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Currencies",
                newName: "Id");
        }
    }
}

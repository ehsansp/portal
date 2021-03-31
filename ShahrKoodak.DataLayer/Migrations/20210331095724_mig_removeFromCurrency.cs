using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShahrKoodak.DataLayer.Migrations
{
    public partial class mig_removeFromCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exchanges_FromCurrencies_FromCurrencyId",
                table: "Exchanges");

            migrationBuilder.DropTable(
                name: "FromCurrencies");

            migrationBuilder.DropIndex(
                name: "IX_Exchanges_FromCurrencyId",
                table: "Exchanges");

            migrationBuilder.DropColumn(
                name: "FromCurrencyId",
                table: "Exchanges");

            migrationBuilder.AddColumn<bool>(
                name: "tousdt",
                table: "Exchanges",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tousdt",
                table: "Exchanges");

            migrationBuilder.AddColumn<int>(
                name: "FromCurrencyId",
                table: "Exchanges",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FromCurrencies",
                columns: table => new
                {
                    FromCurrencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FromCurrencies", x => x.FromCurrencyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_FromCurrencyId",
                table: "Exchanges",
                column: "FromCurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exchanges_FromCurrencies_FromCurrencyId",
                table: "Exchanges",
                column: "FromCurrencyId",
                principalTable: "FromCurrencies",
                principalColumn: "FromCurrencyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalBuilder.DataLayer.Migrations
{
    public partial class mig_Exchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ToCurrencies",
                columns: table => new
                {
                    ToCurrencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToCurrencies", x => x.ToCurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "Exchanges",
                columns: table => new
                {
                    ExchangeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<string>(nullable: true),
                    ToCurrencyId = table.Column<int>(nullable: false),
                    FromCurrencyId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchanges", x => x.ExchangeId);
                    table.ForeignKey(
                        name: "FK_Exchanges_FromCurrencies_FromCurrencyId",
                        column: x => x.FromCurrencyId,
                        principalTable: "FromCurrencies",
                        principalColumn: "FromCurrencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exchanges_ToCurrencies_ToCurrencyId",
                        column: x => x.ToCurrencyId,
                        principalTable: "ToCurrencies",
                        principalColumn: "ToCurrencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_FromCurrencyId",
                table: "Exchanges",
                column: "FromCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_ToCurrencyId",
                table: "Exchanges",
                column: "ToCurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exchanges");

            migrationBuilder.DropTable(
                name: "FromCurrencies");

            migrationBuilder.DropTable(
                name: "ToCurrencies");
        }
    }
}

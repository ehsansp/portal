using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalBuilder.DataLayer.Migrations
{
    public partial class mig_ProductStatus2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VaziatId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Vaziats",
                columns: table => new
                {
                    VaziatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaziats", x => x.VaziatId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_VaziatId",
                table: "Product",
                column: "VaziatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Vaziats_VaziatId",
                table: "Product",
                column: "VaziatId",
                principalTable: "Vaziats",
                principalColumn: "VaziatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Vaziats_VaziatId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Vaziats");

            migrationBuilder.DropIndex(
                name: "IX_Product_VaziatId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "VaziatId",
                table: "Product");
        }
    }
}

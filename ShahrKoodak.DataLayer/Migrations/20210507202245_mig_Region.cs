using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShahrKoodak.DataLayer.Migrations
{
    public partial class mig_Region : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_RegionId",
                table: "Product",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Regions_RegionId",
                table: "Product",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Regions_RegionId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Product_RegionId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Product");
        }
    }
}

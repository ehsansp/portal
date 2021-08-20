using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalBuilder.DataLayer.Migrations
{
    public partial class mig_TypeAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeAdId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeAds",
                columns: table => new
                {
                    typeAdId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeAdTitle = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAds", x => x.typeAdId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_TypeAdId",
                table: "Product",
                column: "TypeAdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_TypeAds_TypeAdId",
                table: "Product",
                column: "TypeAdId",
                principalTable: "TypeAds",
                principalColumn: "typeAdId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_TypeAds_TypeAdId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "TypeAds");

            migrationBuilder.DropIndex(
                name: "IX_Product_TypeAdId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "TypeAdId",
                table: "Product");
        }
    }
}

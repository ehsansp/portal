using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShahrKoodak.DataLayer.Migrations
{
    public partial class shahr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ostan",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShahrId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Shahr",
                columns: table => new
                {
                    ShahrId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupTitle = table.Column<string>(maxLength: 200, nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    OstanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shahr", x => x.ShahrId);
                    table.ForeignKey(
                        name: "FK_Shahr_Shahr_OstanId",
                        column: x => x.OstanId,
                        principalTable: "Shahr",
                        principalColumn: "ShahrId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Ostan",
                table: "Product",
                column: "Ostan");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ShahrId",
                table: "Product",
                column: "ShahrId");

            migrationBuilder.CreateIndex(
                name: "IX_Shahr_OstanId",
                table: "Shahr",
                column: "OstanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Shahr_Ostan",
                table: "Product",
                column: "Ostan",
                principalTable: "Shahr",
                principalColumn: "ShahrId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Shahr_ShahrId",
                table: "Product",
                column: "ShahrId",
                principalTable: "Shahr",
                principalColumn: "ShahrId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Shahr_Ostan",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Shahr_ShahrId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Shahr");

            migrationBuilder.DropIndex(
                name: "IX_Product_Ostan",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ShahrId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Ostan",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ShahrId",
                table: "Product");
        }
    }
}

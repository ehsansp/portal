using Microsoft.EntityFrameworkCore.Migrations;

namespace ShahrKoodak.DataLayer.Migrations
{
    public partial class aaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductEpisodes_Product_ProductId",
                table: "ProductEpisodes");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "ProductEpisodes");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductEpisodes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEpisodes_Product_ProductId",
                table: "ProductEpisodes",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductEpisodes_Product_ProductId",
                table: "ProductEpisodes");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductEpisodes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "ProductEpisodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEpisodes_Product_ProductId",
                table: "ProductEpisodes",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

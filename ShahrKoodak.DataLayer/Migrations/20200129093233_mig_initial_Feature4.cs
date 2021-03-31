using Microsoft.EntityFrameworkCore.Migrations;

namespace ShahrKoodak.DataLayer.Migrations
{
    public partial class mig_initial_Feature4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "ProductGroup",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Features",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_FeatureId",
                table: "ProductGroup",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroup_Features_FeatureId",
                table: "ProductGroup",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "FeatureId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroup_Features_FeatureId",
                table: "ProductGroup");

            migrationBuilder.DropIndex(
                name: "IX_ProductGroup_FeatureId",
                table: "ProductGroup");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "ProductGroup");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Features");
        }
    }
}

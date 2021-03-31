using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShahrKoodak.DataLayer.Migrations
{
    public partial class initial_ProductFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductGroupGroupId",
                table: "ProductFeatures",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FeatureGroups",
                columns: table => new
                {
                    FG_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FeatureId = table.Column<int>(nullable: false),
                    ProductGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureGroups", x => x.FG_ID);
                    table.ForeignKey(
                        name: "FK_FeatureGroups_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "FeatureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeatureGroups_ProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_ProductGroupGroupId",
                table: "ProductFeatures",
                column: "ProductGroupGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureGroups_FeatureId",
                table: "FeatureGroups",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureGroups_ProductGroupId",
                table: "FeatureGroups",
                column: "ProductGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeatures_ProductGroup_ProductGroupGroupId",
                table: "ProductFeatures",
                column: "ProductGroupGroupId",
                principalTable: "ProductGroup",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeatures_ProductGroup_ProductGroupGroupId",
                table: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "FeatureGroups");

            migrationBuilder.DropIndex(
                name: "IX_ProductFeatures_ProductGroupGroupId",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "ProductGroupGroupId",
                table: "ProductFeatures");
        }
    }
}

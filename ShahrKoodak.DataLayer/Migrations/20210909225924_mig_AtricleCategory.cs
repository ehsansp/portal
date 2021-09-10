using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalBuilder.DataLayer.Migrations
{
    public partial class mig_AtricleCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategories_ArticleCategories_ParentId",
                table: "ArticleCategories");

            migrationBuilder.DropIndex(
                name: "IX_ArticleCategories_ParentId",
                table: "ArticleCategories");

            migrationBuilder.AddColumn<int>(
                name: "ArticleCategoryId",
                table: "ArticleCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_ArticleCategoryId",
                table: "ArticleCategories",
                column: "ArticleCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategories_ArticleCategories_ArticleCategoryId",
                table: "ArticleCategories",
                column: "ArticleCategoryId",
                principalTable: "ArticleCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategories_ArticleCategories_ArticleCategoryId",
                table: "ArticleCategories");

            migrationBuilder.DropIndex(
                name: "IX_ArticleCategories_ArticleCategoryId",
                table: "ArticleCategories");

            migrationBuilder.DropColumn(
                name: "ArticleCategoryId",
                table: "ArticleCategories");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_ParentId",
                table: "ArticleCategories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategories_ArticleCategories_ParentId",
                table: "ArticleCategories",
                column: "ParentId",
                principalTable: "ArticleCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

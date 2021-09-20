using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalBuilder.DataLayer.Migrations
{
    public partial class mig_ColorSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "SiteSettings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ColorSiteColorId",
                table: "SiteSettings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ColorSites",
                columns: table => new
                {
                    ColorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorSites", x => x.ColorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiteSettings_ColorSiteColorId",
                table: "SiteSettings",
                column: "ColorSiteColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteSettings_ColorSites_ColorSiteColorId",
                table: "SiteSettings",
                column: "ColorSiteColorId",
                principalTable: "ColorSites",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteSettings_ColorSites_ColorSiteColorId",
                table: "SiteSettings");

            migrationBuilder.DropTable(
                name: "ColorSites");

            migrationBuilder.DropIndex(
                name: "IX_SiteSettings_ColorSiteColorId",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "ColorSiteColorId",
                table: "SiteSettings");
        }
    }
}

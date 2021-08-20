using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalBuilder.DataLayer.Migrations
{
    public partial class mig_EditShahr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shahr_Shahr_OstanId",
                table: "Shahr");

            migrationBuilder.DropIndex(
                name: "IX_Shahr_OstanId",
                table: "Shahr");

            migrationBuilder.DropColumn(
                name: "OstanId",
                table: "Shahr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OstanId",
                table: "Shahr",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shahr_OstanId",
                table: "Shahr",
                column: "OstanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shahr_Shahr_OstanId",
                table: "Shahr",
                column: "OstanId",
                principalTable: "Shahr",
                principalColumn: "ShahrId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

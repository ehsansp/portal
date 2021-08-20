using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalBuilder.DataLayer.Migrations
{
    public partial class mig_StoreGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Stores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoreId1",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubGroup",
                table: "Stores",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_GroupId",
                table: "Stores",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_StoreId1",
                table: "Stores",
                column: "StoreId1");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_SubGroup",
                table: "Stores",
                column: "SubGroup");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_ProductGroup_GroupId",
                table: "Stores",
                column: "GroupId",
                principalTable: "ProductGroup",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Stores_StoreId1",
                table: "Stores",
                column: "StoreId1",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_ProductGroup_SubGroup",
                table: "Stores",
                column: "SubGroup",
                principalTable: "ProductGroup",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_ProductGroup_GroupId",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Stores_StoreId1",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_ProductGroup_SubGroup",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_GroupId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_StoreId1",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_SubGroup",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "StoreId1",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "SubGroup",
                table: "Stores");
        }
    }
}

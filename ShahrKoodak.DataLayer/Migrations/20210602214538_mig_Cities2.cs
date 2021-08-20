using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalBuilder.DataLayer.Migrations
{
    public partial class mig_Cities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City2s",
                columns: table => new
                {
                    level = table.Column<string>(nullable: true),
                    radius = table.Column<string>(nullable: true),
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    slug = table.Column<string>(nullable: true),
                    parent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City2s", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City2s");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalBuilder.DataLayer.Migrations
{
    public partial class mig_ButtumBanners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ButtomBanners",
                columns: table => new
                {
                    ButtomBannerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageName = table.Column<string>(maxLength: 400, nullable: true),
                    BennerLink = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButtomBanners", x => x.ButtomBannerId);
                });

            migrationBuilder.CreateTable(
                name: "LeftBanner2s",
                columns: table => new
                {
                    LeftBannerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageName = table.Column<string>(maxLength: 400, nullable: true),
                    BennerLink = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeftBanner2s", x => x.LeftBannerId);
                });

            migrationBuilder.CreateTable(
                name: "RightBanner2s",
                columns: table => new
                {
                    RightBannerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageName = table.Column<string>(maxLength: 400, nullable: true),
                    BennerLink = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RightBanner2s", x => x.RightBannerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ButtomBanners");

            migrationBuilder.DropTable(
                name: "LeftBanner2s");

            migrationBuilder.DropTable(
                name: "RightBanner2s");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShahrKoodak.DataLayer.Migrations
{
    public partial class initial_Banner2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeftBanner",
                columns: table => new
                {
                    LeftBannerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageName = table.Column<string>(maxLength: 400, nullable: true),
                    BennerLink = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeftBanner", x => x.LeftBannerId);
                });

            migrationBuilder.CreateTable(
                name: "MiddleBanner",
                columns: table => new
                {
                    LeftBannerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageName = table.Column<string>(maxLength: 400, nullable: true),
                    BennerLink = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiddleBanner", x => x.LeftBannerId);
                });

            migrationBuilder.CreateTable(
                name: "RightBanner",
                columns: table => new
                {
                    LeftBannerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageName = table.Column<string>(maxLength: 400, nullable: true),
                    BennerLink = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RightBanner", x => x.LeftBannerId);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    SliderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SliderImageName = table.Column<string>(maxLength: 400, nullable: false),
                    Text1 = table.Column<string>(maxLength: 400, nullable: true),
                    Text2 = table.Column<string>(maxLength: 400, nullable: true),
                    Text3 = table.Column<string>(maxLength: 400, nullable: true),
                    LinkAddress = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.SliderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeftBanner");

            migrationBuilder.DropTable(
                name: "MiddleBanner");

            migrationBuilder.DropTable(
                name: "RightBanner");

            migrationBuilder.DropTable(
                name: "Slider");
        }
    }
}

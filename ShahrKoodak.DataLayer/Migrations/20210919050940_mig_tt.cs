using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalBuilder.DataLayer.Migrations
{
    public partial class mig_tt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleCategories_ArticleCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    EnTitle = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsWide = table.Column<bool>(nullable: false),
                    ClickCount = table.Column<int>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrandTimelines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    HappenedAt = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandTimelines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactMessageCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false),
                    SendRequestsToEmails = table.Column<string>(nullable: true),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessageCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    EnTitle = table.Column<string>(nullable: true),
                    SortIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DurationInMinute = table.Column<int>(nullable: false),
                    QuestionsCount = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    UseRandomQuestions = table.Column<bool>(nullable: false),
                    CorrectAnswerPoint = table.Column<int>(nullable: false),
                    WrongAnswerNegativePoint = table.Column<int>(nullable: false),
                    PublishAt = table.Column<DateTime>(nullable: true),
                    ExpireAt = table.Column<DateTime>(nullable: true),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaqCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LandingPages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    RouteTitle = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    BackgroundPhoto = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    LinkTitle = table.Column<string>(nullable: true),
                    StartAt = table.Column<DateTime>(nullable: true),
                    EndAt = table.Column<DateTime>(nullable: true),
                    EndingMessage = table.Column<string>(nullable: true),
                    EndingLink = table.Column<string>(nullable: true),
                    EndingLinkTitle = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    UseDarkTheme = table.Column<bool>(nullable: false),
                    ShowCountdownBeforeStart = table.Column<bool>(nullable: false),
                    CountdownMessage = table.Column<string>(nullable: true),
                    ShowCountdownToEnd = table.Column<bool>(nullable: false),
                    ClickCount = table.Column<int>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandingPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    DisplayInMainMenu = table.Column<bool>(nullable: false),
                    DisplayInFooterMenu = table.Column<bool>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    LinkTitle = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    PublishAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SendAsNewsLetter = table.Column<bool>(nullable: false),
                    DisplayAsPopUp = table.Column<bool>(nullable: false),
                    ClickCount = table.Column<int>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperatorRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    SystemName = table.Column<string>(nullable: true),
                    SortIndex = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    RouteTitle = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    PublishAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ViewCount = table.Column<int>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Subtitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false),
                    IsTestimonial = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoGalleries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    RouteTitle = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    DownloadLink = table.Column<string>(nullable: true),
                    PublishAt = table.Column<DateTime>(nullable: true),
                    IsService = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    EnTitle = table.Column<string>(nullable: true),
                    SortIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questionnaires",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    PublishAt = table.Column<DateTime>(nullable: true),
                    ExpireAt = table.Column<DateTime>(nullable: true),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: true),
                    BrandDescription = table.Column<string>(nullable: true),
                    LogoPhoto = table.Column<string>(nullable: true),
                    FavIcon = table.Column<string>(nullable: true),
                    BrandSlogan = table.Column<string>(nullable: true),
                    BrandMission = table.Column<string>(nullable: true),
                    BrandVision = table.Column<string>(nullable: true),
                    PrimaryColor = table.Column<string>(nullable: true),
                    SecondaryColor = table.Column<string>(nullable: true),
                    RedirectToUrl = table.Column<bool>(nullable: false),
                    RedirectUrl = table.Column<string>(nullable: true),
                    AllowSecondLanguage = table.Column<bool>(nullable: false),
                    AdminAllowedIPs = table.Column<string>(nullable: true),
                    ActiveTheme = table.Column<string>(nullable: true),
                    HomePageMode = table.Column<string>(nullable: true),
                    AllowCustomerRegisteration = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    LinkTitle = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false),
                    ClickCount = table.Column<int>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Writer = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    PublishAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false),
                    SendAsNewsLetter = table.Column<bool>(nullable: false),
                    ArticleCategoryId = table.Column<int>(nullable: false),
                    SubGroup = table.Column<int>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleCategories_ArticleCategoryId",
                        column: x => x.ArticleCategoryId,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleCategories_SubGroup",
                        column: x => x.SubGroup,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BankId = table.Column<int>(nullable: false),
                    BranchTitle = table.Column<string>(nullable: true),
                    AccountOwner = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    ShebaNumber = table.Column<string>(nullable: true),
                    SortIndex = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    SendRequestsToEmails = table.Column<string>(nullable: true),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankDepositRequests",
                columns: table => new
                {
                    BankDepositId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    BankAccountId = table.Column<int>(nullable: false),
                    DepositedAt = table.Column<DateTime>(nullable: false),
                    DepositorName = table.Column<string>(nullable: true),
                    NationalCode = table.Column<string>(nullable: true),
                    Cellphone = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    BankId = table.Column<int>(nullable: false),
                    BranchTitle = table.Column<string>(nullable: true),
                    ReceiptCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TrackingCode = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: true),
                    ValidatedBy = table.Column<int>(nullable: true),
                    ValidatedAt = table.Column<DateTime>(nullable: true),
                    ValidationNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDepositRequests", x => x.BankDepositId);
                    table.ForeignKey(
                        name: "FK_BankDepositRequests_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CateogryId = table.Column<int>(nullable: true),
                    SenderFirstName = table.Column<string>(nullable: true),
                    SenderLastName = table.Column<string>(nullable: true),
                    NationalCode = table.Column<string>(nullable: true),
                    Cellphone = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TrackingCode = table.Column<string>(nullable: true),
                    ReviewedBy = table.Column<int>(nullable: true),
                    ReviewedAt = table.Column<DateTime>(nullable: true),
                    ReviewNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactMessages_ContactMessageCategories_CateogryId",
                        column: x => x.CateogryId,
                        principalTable: "ContactMessageCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamInstances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    AnsweredAt = table.Column<DateTime>(nullable: true),
                    ExamId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    QAs = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamInstances_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    ExamId = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    CorrectAnswer = table.Column<string>(nullable: true),
                    OptionA = table.Column<string>(nullable: true),
                    OptionB = table.Column<string>(nullable: true),
                    OptionC = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faqs_FaqCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "FaqCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    EncryptedPassword = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    LastPasswordChangedAt = table.Column<DateTime>(nullable: true),
                    FirstLoginAt = table.Column<DateTime>(nullable: true),
                    LastLoginAt = table.Column<DateTime>(nullable: true),
                    LastLoginAttemptAt = table.Column<DateTime>(nullable: true),
                    LastLoginAttemptsCount = table.Column<int>(nullable: false),
                    LastIP = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Cellphone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operators_OperatorRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OperatorRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Photographer = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false),
                    GalleryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_PhotoGalleries_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "PhotoGalleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    ManagerName = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    WorkTimes = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    DisplayInContactPage = table.Column<bool>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    EncryptedPassword = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    LastPasswordChangedAt = table.Column<DateTime>(nullable: true),
                    FirstLoginAt = table.Column<DateTime>(nullable: true),
                    LastLoginAt = table.Column<DateTime>(nullable: true),
                    LastLoginAttemptAt = table.Column<DateTime>(nullable: true),
                    LastLoginAttemptsCount = table.Column<int>(nullable: false),
                    LastIP = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    NationalCode = table.Column<string>(nullable: true),
                    Cellphone = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    BourseExchangeCode = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EducationLevelId = table.Column<int>(nullable: true),
                    EducationField = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ReferrerCode = table.Column<string>(nullable: true),
                    TrackingCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobAds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    MinEducationLevelId = table.Column<int>(nullable: true),
                    MaleIsAccepted = table.Column<bool>(nullable: false),
                    FemaleIsAccepted = table.Column<bool>(nullable: false),
                    IsFulltime = table.Column<bool>(nullable: false),
                    IsPartTime = table.Column<bool>(nullable: false),
                    IsOutsource = table.Column<bool>(nullable: false),
                    IsInternship = table.Column<bool>(nullable: false),
                    PublishAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ViewCount = table.Column<int>(nullable: false),
                    SendRequestsToEmails = table.Column<string>(nullable: true),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobAds_EducationLevels_MinEducationLevelId",
                        column: x => x.MinEducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobAds_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireInstances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    AnsweredAt = table.Column<DateTime>(nullable: true),
                    QuestionnaireId = table.Column<int>(nullable: false),
                    QAs = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionnaireInstances_Questionnaires_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    QuestionnaireId = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    OptionA = table.Column<string>(nullable: true),
                    OptionB = table.Column<string>(nullable: true),
                    OptionC = table.Column<string>(nullable: true),
                    OptionD = table.Column<string>(nullable: true),
                    OptionE = table.Column<string>(nullable: true),
                    OptionF = table.Column<string>(nullable: true),
                    OptionACount = table.Column<int>(nullable: false),
                    OptionBCount = table.Column<int>(nullable: false),
                    OptionCCount = table.Column<int>(nullable: false),
                    OptionDCount = table.Column<int>(nullable: false),
                    OptionECount = table.Column<int>(nullable: false),
                    OptionFCount = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionnaireQuestions_Questionnaires_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Education = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    OrganizationUnitId = table.Column<int>(nullable: false),
                    StaffPositionId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    SortIndex = table.Column<int>(nullable: false),
                    IsSecondLanguage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staves_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staves_OrganizationUnits_OrganizationUnitId",
                        column: x => x.OrganizationUnitId,
                        principalTable: "OrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staves_StaffPositions_StaffPositionId",
                        column: x => x.StaffPositionId,
                        principalTable: "StaffPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobAdRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    JobAdId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsAccpeted = table.Column<bool>(nullable: true),
                    ValidatedBy = table.Column<int>(nullable: true),
                    ValidatedAt = table.Column<DateTime>(nullable: true),
                    InterviewDate = table.Column<DateTime>(nullable: true),
                    InterviewInviteMessage = table.Column<string>(nullable: true),
                    ValidationNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAdRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobAdRequests_JobAds_JobAdId",
                        column: x => x.JobAdId,
                        principalTable: "JobAds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_ParentId",
                table: "ArticleCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SubGroup",
                table: "Articles",
                column: "SubGroup");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_BankId",
                table: "BankAccounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDepositRequests_BankId",
                table: "BankDepositRequests",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ProvinceId",
                table: "Branches",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactMessages_CateogryId",
                table: "ContactMessages",
                column: "CateogryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_EducationLevelId",
                table: "Customers",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ProvinceId",
                table: "Customers",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamInstances_ExamId",
                table: "ExamInstances",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_ExamId",
                table: "ExamQuestions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_CategoryId",
                table: "Faqs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAdRequests_JobAdId",
                table: "JobAdRequests",
                column: "JobAdId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAds_MinEducationLevelId",
                table: "JobAds",
                column: "MinEducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAds_ProvinceId",
                table: "JobAds",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentId",
                table: "Menus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_RoleId",
                table: "Operators",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_GalleryId",
                table: "Photos",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireInstances_QuestionnaireId",
                table: "QuestionnaireInstances",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireQuestions_QuestionnaireId",
                table: "QuestionnaireQuestions",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Staves_BranchId",
                table: "Staves",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Staves_OrganizationUnitId",
                table: "Staves",
                column: "OrganizationUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Staves_StaffPositionId",
                table: "Staves",
                column: "StaffPositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "BankDepositRequests");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "BrandTimelines");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "ContactMessages");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ExamInstances");

            migrationBuilder.DropTable(
                name: "ExamQuestions");

            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropTable(
                name: "JobAdRequests");

            migrationBuilder.DropTable(
                name: "LandingPages");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "QuestionnaireInstances");

            migrationBuilder.DropTable(
                name: "QuestionnaireQuestions");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "Staves");

            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "ContactMessageCategories");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "FaqCategories");

            migrationBuilder.DropTable(
                name: "JobAds");

            migrationBuilder.DropTable(
                name: "OperatorRoles");

            migrationBuilder.DropTable(
                name: "PhotoGalleries");

            migrationBuilder.DropTable(
                name: "Questionnaires");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "OrganizationUnits");

            migrationBuilder.DropTable(
                name: "StaffPositions");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}

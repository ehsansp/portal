﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShahrKoodak.DataLayer.Context;

namespace ShahrKoodak.DataLayer.Migrations
{
    [DbContext(typeof(ShahrContext))]
    [Migration("20200406155003_mig_Store")]
    partial class mig_Store
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Agent.Agent", b =>
                {
                    b.Property<int>("AgentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgentLocation")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("AgentName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("AgentId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Order.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiscountCode")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("DiscountPercent");

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime?>("StartDate");

                    b.Property<int?>("UsableCount");

                    b.HasKey("DiscountId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Order.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsFinaly");

                    b.Property<int>("OrderSum");

                    b.Property<int>("UserId");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Order.OrderDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<int>("OrderId");

                    b.Property<int>("Price");

                    b.Property<int>("ProductId");

                    b.HasKey("DetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Permission.Permissoin", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParentID");

                    b.Property<string>("PermissionTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("PermissionId");

                    b.HasIndex("ParentID");

                    b.ToTable("Permissoins");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Permission.RolePermission", b =>
                {
                    b.Property<int>("RP_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionId");

                    b.Property<int>("RoleId");

                    b.HasKey("RP_Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.Feature", b =>
                {
                    b.Property<int>("FeatureId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FeatureTitle")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<int>("GroupId");

                    b.HasKey("FeatureId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.FeatureGroup", b =>
                {
                    b.Property<int>("FG_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FeatureId");

                    b.Property<int>("ProductGroupId");

                    b.HasKey("FG_ID");

                    b.HasIndex("FeatureId");

                    b.HasIndex("ProductGroupId");

                    b.ToTable("FeatureGroups");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Discount");

                    b.Property<string>("PackageImage")
                        .IsRequired();

                    b.Property<string>("PakageName")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<int>("Price1");

                    b.Property<int>("Price2");

                    b.Property<int>("ProductId");

                    b.HasKey("PackageId");

                    b.HasIndex("ProductId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("DemoFileName")
                        .HasMaxLength(100);

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsActive");

                    b.Property<int>("Mantaghe")
                        .HasMaxLength(450);

                    b.Property<string>("Mobile")
                        .HasMaxLength(450);

                    b.Property<int?>("OtherProduct");

                    b.Property<int?>("OtherProduct2");

                    b.Property<int?>("OtherProduct3");

                    b.Property<string>("ProductDescription")
                        .IsRequired();

                    b.Property<int?>("ProductId1");

                    b.Property<string>("ProductImageName")
                        .HasMaxLength(50);

                    b.Property<string>("ProductTitle")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("ProductTitle2")
                        .HasMaxLength(450);

                    b.Property<string>("ProductTitle3")
                        .HasMaxLength(450);

                    b.Property<string>("ShortDescription");

                    b.Property<int>("StarNumber");

                    b.Property<int?>("SubGroup");

                    b.Property<string>("Tags")
                        .HasMaxLength(600);

                    b.Property<string>("Tel1")
                        .HasMaxLength(450);

                    b.Property<string>("Tel2")
                        .HasMaxLength(450);

                    b.Property<string>("Tel3")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("ProductId");

                    b.HasIndex("GroupId");

                    b.HasIndex("ProductId1");

                    b.HasIndex("SubGroup");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.ProductComment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasMaxLength(700);

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsAdminRead");

                    b.Property<bool>("IsDelete");

                    b.Property<int>("ProductId");

                    b.Property<int>("UserId");

                    b.HasKey("CommentId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("ProductComment");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.ProductEpisode", b =>
                {
                    b.Property<int>("EpisodeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EpisodeFileName");

                    b.Property<TimeSpan>("EpisodeTime");

                    b.Property<string>("EpisodeTitle")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<bool>("IsFree");

                    b.Property<int>("ProductId");

                    b.HasKey("EpisodeId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductEpisodes");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.ProductFeature", b =>
                {
                    b.Property<int>("PF_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FeatureId");

                    b.Property<int?>("ProductGroupGroupId");

                    b.Property<int>("ProductId");

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("PF_ID");

                    b.HasIndex("FeatureId");

                    b.HasIndex("ProductGroupGroupId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductFeatures");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.ProductGroup", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FeatureId");

                    b.Property<string>("GroupTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ImageName");

                    b.Property<bool>("IsDelete");

                    b.Property<int?>("ParentId");

                    b.HasKey("GroupId");

                    b.HasIndex("FeatureId");

                    b.HasIndex("ParentId");

                    b.ToTable("ProductGroup");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.ProductSharayet", b =>
                {
                    b.Property<int>("SharayetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<int>("ProductId");

                    b.HasKey("SharayetId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductSharayets");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.ProductVizhegi", b =>
                {
                    b.Property<int>("VizhegiId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<int>("ProductId");

                    b.HasKey("VizhegiId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductVizhegis");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.UserProduct", b =>
                {
                    b.Property<int>("US_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId");

                    b.Property<int>("UserId");

                    b.HasKey("US_Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProduct");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Slider.ButtomBanner", b =>
                {
                    b.Property<int>("ButtomBannerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BennerLink")
                        .HasMaxLength(400);

                    b.Property<string>("ImageName")
                        .HasMaxLength(400);

                    b.HasKey("ButtomBannerId");

                    b.ToTable("ButtomBanners");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Slider.LeftBanner", b =>
                {
                    b.Property<int>("LeftBannerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BennerLink")
                        .HasMaxLength(400);

                    b.Property<string>("ImageName")
                        .HasMaxLength(400);

                    b.HasKey("LeftBannerId");

                    b.ToTable("LeftBanner");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Slider.LeftBanner2", b =>
                {
                    b.Property<int>("LeftBannerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BennerLink")
                        .HasMaxLength(400);

                    b.Property<string>("ImageName")
                        .HasMaxLength(400);

                    b.HasKey("LeftBannerId");

                    b.ToTable("LeftBanner2s");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Slider.MiddleBanner", b =>
                {
                    b.Property<int>("LeftBannerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BennerLink")
                        .HasMaxLength(400);

                    b.Property<string>("ImageName")
                        .HasMaxLength(400);

                    b.HasKey("LeftBannerId");

                    b.ToTable("MiddleBanner");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Slider.RightBanner", b =>
                {
                    b.Property<int>("LeftBannerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BennerLink")
                        .HasMaxLength(400);

                    b.Property<string>("ImageName")
                        .HasMaxLength(400);

                    b.HasKey("LeftBannerId");

                    b.ToTable("RightBanner");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Slider.RightBanner2", b =>
                {
                    b.Property<int>("RightBannerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BennerLink")
                        .HasMaxLength(400);

                    b.Property<string>("ImageName")
                        .HasMaxLength(400);

                    b.HasKey("RightBannerId");

                    b.ToTable("RightBanner2s");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Slider.Slider", b =>
                {
                    b.Property<int>("SliderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LinkAddress")
                        .HasMaxLength(400);

                    b.Property<string>("SliderImageName")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("Text1")
                        .HasMaxLength(400);

                    b.Property<string>("Text2")
                        .HasMaxLength(400);

                    b.Property<string>("Text3")
                        .HasMaxLength(400);

                    b.HasKey("SliderId");

                    b.ToTable("Slider");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.User.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.User.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.User.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Banner");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Instagram")
                        .HasMaxLength(200);

                    b.Property<string>("Logo");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<string>("Shoar")
                        .HasMaxLength(200);

                    b.Property<string>("Telegram")
                        .HasMaxLength(200);

                    b.Property<int?>("UserId");

                    b.HasKey("StoreId");

                    b.HasIndex("UserId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.User.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActiveCode")
                        .HasMaxLength(50);

                    b.Property<string>("Address")
                        .HasMaxLength(500);

                    b.Property<int>("CityId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Family")
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Mail")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("PostCode")
                        .HasMaxLength(200);

                    b.Property<DateTime>("RegisterDate");

                    b.Property<int?>("StoreId");

                    b.Property<string>("Tel")
                        .HasMaxLength(200);

                    b.Property<string>("UserAvatar")
                        .HasMaxLength(200);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("WebSite")
                        .HasMaxLength(200);

                    b.Property<string>("WhatsApp")
                        .HasMaxLength(200);

                    b.HasKey("UserId");

                    b.HasIndex("CityId");

                    b.HasIndex("StoreId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.User.UserDiscountCode", b =>
                {
                    b.Property<int>("UD_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiscountId");

                    b.Property<int>("UserId");

                    b.HasKey("UD_Id");

                    b.HasIndex("DiscountId");

                    b.HasIndex("UserId");

                    b.ToTable("UserDiscountCodes");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.User.UserRole", b =>
                {
                    b.Property<int>("UR_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("UR_Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Wallet.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool>("IsPay");

                    b.Property<int>("TypeId");

                    b.Property<int>("UserId");

                    b.HasKey("WalletId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Wallet.WalletType", b =>
                {
                    b.Property<int>("TypeId");

                    b.Property<string>("TypeTitle")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("TypeId");

                    b.ToTable("WalletTypes");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Order.Order", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Order.OrderDetail", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.Order.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Permission.Permissoin", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.Permission.Permissoin")
                        .WithMany("Permissions")
                        .HasForeignKey("ParentID");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Permission.RolePermission", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.Permission.Permissoin", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShahrKoodak.DataLayer.Entities.User.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.FeatureGroup", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.Feature", "Feature")
                        .WithMany("FeatureGroups")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.ProductGroup", "ProductGroup")
                        .WithMany()
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.Package", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.product", "Product")
                        .WithMany("Packages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.product", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.ProductGroup", "ProductGroup")
                        .WithMany("Products")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.product")
                        .WithMany("Products")
                        .HasForeignKey("ProductId1");

                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.ProductGroup", "Group")
                        .WithMany("SubGroup")
                        .HasForeignKey("SubGroup");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.ProductComment", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.product", "Product")
                        .WithMany("ProductComments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShahrKoodak.DataLayer.Entities.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.ProductEpisode", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.product", "Product")
                        .WithMany("ProductEpisodes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.ProductFeature", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.Feature", "Feature")
                        .WithMany("ProductFeatures")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.ProductGroup")
                        .WithMany("ProductFeatures")
                        .HasForeignKey("ProductGroupGroupId");

                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.product", "Product")
                        .WithMany("ProductFeatures")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.ProductGroup", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.Feature")
                        .WithMany("ProductGroups")
                        .HasForeignKey("FeatureId");

                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.ProductGroup")
                        .WithMany("ProductGroups")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.ProductSharayet", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.product", "Product")
                        .WithMany("ProductSharayets")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.ProductVizhegi", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.product", "Product")
                        .WithMany("ProductVizhegis")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Product.UserProduct", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.Product.product", "Product")
                        .WithMany("UserProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShahrKoodak.DataLayer.Entities.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.User.Store", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.User.User", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.User.City", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShahrKoodak.DataLayer.Entities.User.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId");
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.User.UserDiscountCode", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.Order.Discount", "Discount")
                        .WithMany("UserDiscountCodes")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShahrKoodak.DataLayer.Entities.User.User", "User")
                        .WithMany("UserDiscountCodes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.User.UserRole", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.User.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShahrKoodak.DataLayer.Entities.User.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShahrKoodak.DataLayer.Entities.Wallet.Wallet", b =>
                {
                    b.HasOne("ShahrKoodak.DataLayer.Entities.Wallet.WalletType", "WalletType")
                        .WithMany("Wallets")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShahrKoodak.DataLayer.Entities.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

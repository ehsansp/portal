using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShahrKoodak.DataLayer.Entities.Agent;
using ShahrKoodak.DataLayer.Entities.Order;
using ShahrKoodak.DataLayer.Entities.Permission;
using ShahrKoodak.DataLayer.Entities.Product;
using ShahrKoodak.DataLayer.Entities.Question;
using ShahrKoodak.DataLayer.Entities.Slider;
using ShahrKoodak.DataLayer.Entities.User;
using ShahrKoodak.DataLayer.Entities.Wallet;

namespace ShahrKoodak.DataLayer.Context
{
    public class ShahrContext:DbContext
    {
        public ShahrContext(DbContextOptions<ShahrContext> options) : base(options)
        {
            
        }

        #region User

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserDiscountCode> UserDiscountCodes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<TypeAd> TypeAds { get; set; }
        public DbSet<Withdrawal> Withdrawals { get; set; }
        public DbSet<WithdrawalType> WithdrawalTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        #endregion


        #region Permission

        public DbSet<Permissoin> Permissoins { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        #endregion

        #region Order

        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        #endregion

        #region Product

        public DbSet<product> Product { get; set; }
        public DbSet<ProductComment> ProductComment { get; set; }
        public DbSet<ProductGroup> ProductGroup { get; set; }
        public DbSet<UserProduct> UserProduct { get; set; }
        public DbSet<ProductEpisode> ProductEpisodes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<FeatureGroup> FeatureGroups { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<ProductSharayet> ProductSharayets { get; set; }
        public DbSet<ProductVizhegi> ProductVizhegis { get; set; }

        #endregion

        #region Question

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        #endregion

        #region Wallet

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<ToCurrency> ToCurrencies { get; set; }

        #endregion

        #region Agent

        public DbSet<Agent> Agents { get; set; }

        #endregion

        #region Banner

        public DbSet<LeftBanner> LeftBanner { get; set; }
        public DbSet<MiddleBanner> MiddleBanner { get; set; }
        public DbSet<RightBanner> RightBanner { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<LeftBanner2> LeftBanner2s { get; set; }
        public DbSet<RightBanner2> RightBanner2s { get; set; }
        public DbSet<ButtomBanner> ButtomBanners { get; set; }

        #endregion

    }
}

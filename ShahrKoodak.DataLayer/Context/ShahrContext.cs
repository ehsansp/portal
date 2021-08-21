using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PortalBuilder.Models;


namespace PortalBuilder.DataLayer.Context
{
    public class ShahrContext:DbContext
    {
        public ShahrContext(DbContextOptions<ShahrContext> options) : base(options)
        {
            
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankDepositRequest> BankDepositRequests { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BrandTimeline> BrandTimelines { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<ContactMessageCategory> ContactMessageCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamInstance> ExamInstances { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<FAQ> Faqs { get; set; }
        public DbSet<FAQCategory> FaqCategories { get; set; }
        public DbSet<JobAd> JobAds { get; set; }
        public DbSet<JobAdRequest> JobAdRequests { get; set; }
        public DbSet<LandingPage> LandingPages { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<OperatorRole> OperatorRoles { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PhotoGallery> PhotoGalleries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<QuestionnaireInstance> QuestionnaireInstances { get; set; }
        public DbSet<QuestionnaireQuestion> QuestionnaireQuestions { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Staff> Staves { get; set; }
        public DbSet<StaffPosition> StaffPositions { get; set; }
    }
}

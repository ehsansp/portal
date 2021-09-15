using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortalBuilder.Core.Services.generic;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.Models;
using PortalsBuilder.Web.Models;

namespace PortalsBuilder.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private ICustomerService _customerService;
        private readonly IGenericRepository<Staff> staff;
        private readonly IGenericRepository<StaffPosition> staffPosition;
        private readonly IGenericRepository<JobAdRequest> jobAdRequest;
        private readonly IGenericRepository<Menu> menu;
        private readonly IGenericRepository<SiteSetting> siteSetting;
        private readonly IGenericRepository<Banner> banner;
        private readonly IGenericRepository<Customer> customer;
        private readonly IGenericRepository<Branch> branch;
        private readonly IGenericRepository<BankAccount> bankAccount;
        private readonly IGenericRepository<Certificate> certificate1;
        private readonly IGenericRepository<FAQ> fAQ;
        private readonly IGenericRepository<Article> article;

        public HomeController(
            ILogger<HomeController> logger, 
            ICustomerService customerService,
            IGenericRepository<Staff> staff,
            IGenericRepository<Customer> customer,
            IGenericRepository<Branch> branch,
            IGenericRepository<BankAccount> bankAccount,
            IGenericRepository<Certificate> certificate,
            IGenericRepository<FAQ> fAQ,
            IGenericRepository<Article> article,
            IGenericRepository<StaffPosition> StaffPosition,
            IGenericRepository<JobAdRequest> JobAdRequest,
             IGenericRepository<Menu> menu,
              IGenericRepository<SiteSetting> siteSetting,
              IGenericRepository<Banner> banner


            )
        {
            _logger = logger;
            _customerService = customerService;
            this.staff = staff;
            this.customer = customer;
            this.branch = branch;
            this.bankAccount = bankAccount;
            certificate1 = certificate;
            this.fAQ = fAQ;
            this.article = article;
            this.staffPosition = StaffPosition;
            jobAdRequest = JobAdRequest;
            this.menu = menu;
            this.siteSetting = siteSetting;
            this.banner = banner;
        }
        //[ChildActionOnly]
        //[OutputCache(Duration = 5 * 60)]
        public IActionResult Header() {
            //var res = new MenuAndBrandVM();
            //res.menuList.AddRange(menu.GetAll());
            //res.SiteSetting = siteSetting.GetAll().FirstOrDefault();

            return PartialView("Header");
        }
        public IActionResult Footer()
        {
            //var res = new MenuAndBrandVM();
            //res.menuList.AddRange(menu.GetAll());
            //res.SiteSetting = siteSetting.GetAll().FirstOrDefault();

            return PartialView("Footer");
        }

        public IActionResult Head()
        {
            //var res = new menuandbrandvm();
            //res.menulist.addrange(menu.getall());
            //res.sitesetting = sitesetting.getall().firstordefault();

            return PartialView("Head");
        }

       public  class IndexVM
        {
            public Banner banner { get; set; }
            public SiteSetting siteSetting { get; set; }
        }

        public IActionResult Index()
        {

            var res = banner.GetAll();
            var ss = siteSetting.GetAll();

            return View(new IndexVM { banner= res.Where(x=>x.IsActive).FirstOrDefault(),siteSetting  =ss.FirstOrDefault() });
        }
        [Route("about")]
        public IActionResult about()
        {
            return View();
        }
        [Route("team")]
        public IActionResult team()
        {

            var children = new string[] { "OrganizationUnit", "StaffPosition" };
            var res = staff.EntityWithEagerLoad(null,children);
            return View(res);
        }
        [Route("ColleaguesAndCustomers")]
        public IActionResult ColleaguesAndCustomers()
        {
            var res = customer.GetAll();
            //var res = new List<PortalBuilder.Models.Customer>();
            //res.Add(new Customer { FirstName = "محمد", LastName = "موسوی", JobTitle = "کارگذار بورس", Description = "بسیار خوش فکر و بیان ارتباطات. نقاط عطف ، مهلت و کار سریع را پاک کنید. صبر. صبر بی نهایت. بدون میانبر حتی اگر مشتری بی خیال باشد. بهترین قسمت ... همیشه حل مشکلات با ایده های عالی و عالی!." });
            //res.Add(new Customer { FirstName = "علی", LastName = "عرفانی", JobTitle = "کارگذار بورس", Description = "بسیار خوش فکر و بیان ارتباطات. نقاط عطف ، مهلت و کار سریع را پاک کنید. صبر. صبر بی نهایت. بدون میانبر حتی اگر مشتری بی خیال باشد. بهترین قسمت ... همیشه حل مشکلات با ایده های عالی و عالی!." });
            //res.Add(new Customer { FirstName = "رضا", LastName = "مسعودی", JobTitle = "کارگذار بورس", Description = "بسیار خوش فکر و بیان ارتباطات. نقاط عطف ، مهلت و کار سریع را پاک کنید. صبر. صبر بی نهایت. بدون میانبر حتی اگر مشتری بی خیال باشد. بهترین قسمت ... همیشه حل مشکلات با ایده های عالی و عالی!." });
            //res.Add(new Customer { FirstName = "آمنه", LastName = "عبدالهی", JobTitle = "کارگذار بورس", Description = "بسیار خوش فکر و بیان ارتباطات. نقاط عطف ، مهلت و کار سریع را پاک کنید. صبر. صبر بی نهایت. بدون میانبر حتی اگر مشتری بی خیال باشد. بهترین قسمت ... همیشه حل مشکلات با ایده های عالی و عالی!." });
            //res.Add(new Customer { FirstName = "روژا", LastName = "کاسبی", JobTitle = "کارگذار بورس", Description = "بسیار خوش فکر و بیان ارتباطات. نقاط عطف ، مهلت و کار سریع را پاک کنید. صبر. صبر بی نهایت. بدون میانبر حتی اگر مشتری بی خیال باشد. بهترین قسمت ... همیشه حل مشکلات با ایده های عالی و عالی!." });
            return View(res);
        }

        [Route("Branch")]
        public IActionResult Branch()
        {
            //var res = new List<PortalBuilder.Models.Branch>();
            //res.Add(new PortalBuilder.Models.Branch
            //{
            //    Title = "شعبه زعفرانیه",
            //    ManagerName = "محسن سلامی",
            //    WorkTimes = "از 8 تا 15"
            //    ,
            //    Description = "پرداخت وام",
            //    Phone = "88284724",
            //    Email = "kargo@gmail.com",
            //    Address = "محله زعفرانیه در منطقه‌ی یک شهرداری تهران",
            //    City = "تهران",
            //    PostalCode = "23456765",
            //    Province = new Province { Title = "تهران" }
            //});

            //res.Add(new PortalBuilder.Models.Branch
            //{
            //    Title = "شعبه مجیدیه",
            //    ManagerName = "عباس سلامی",
            //    WorkTimes = "از 8 تا 15"
            //   ,
            //    Description = "مشاوره",
            //    Phone = "44252452",
            //    Email = "moshavere@gmail.com",
            //    Address = "محله مجیدیه در منطقه‌ی یک شهرداری تهران",
            //    City = "تهران",
            //    PostalCode = "6356363",
            //    Province = new Province { Title = "تهران" }
            //});
            var res = branch.GetAll();

            return View(res);
        }



        [Route("SocialMedia")]
        public IActionResult SocialMedia()
        {


            //var res = new List<PortalBuilder.Models.Branch>();
            //res.Add(new PortalBuilder.Models.Branch
            //{
            //    Title = "شعبه زعفرانیه",
            //    ManagerName = "محسن سلامی",
            //    WorkTimes = "از 8 تا 15",
            //    Photo = "https://localhost:44323/images/download.jpg",
            //    Description = "پرداخت وام",
            //    Phone = "88284724",
            //    Email = "kargo@gmail.com",
            //    Address = "محله زعفرانیه در منطقه‌ی یک شهرداری تهران",
            //    City = "تهران",
            //    PostalCode = "23456765",
            //    Province = new Province { Title = "تهران" }
            //});

            //res.Add(new PortalBuilder.Models.Branch
            //{
            //    Title = "شعبه مجیدیه",
            //    ManagerName = "عباس سلامی",
            //    WorkTimes = "از 8 تا 15",
            //    Photo = "https://localhost:44323/images/download.jpg",
            //    Description = "مشاوره",
            //    Phone = "44252452",
            //    Email = "moshavere@gmail.com",
            //    Address = "محله مجیدیه در منطقه‌ی یک شهرداری تهران",
            //    City = "تهران",
            //    PostalCode = "6356363",
            //    Province = new Province { Title = "تهران" }
            //});
            //res.Add(new PortalBuilder.Models.Branch
            //{
            //    Title = "شعبه مجیدیه",
            //    ManagerName = "عباس سلامی",
            //    WorkTimes = "از 8 تا 15",
            //    Photo = "https://localhost:44323/images/download2.jpg",
            //    Description = "مشاوره",
            //    Phone = "44252452",
            //    Email = "moshavere@gmail.com",
            //    Address = "محله مجیدیه در منطقه‌ی یک شهرداری تهران",
            //    City = "تهران",
            //    PostalCode = "6356363",
            //    Province = new Province { Title = "تهران" }
            //});
            var res = branch.GetAll();
            return View(res);
        }


        [Route("BankAccountPage")]
        public IActionResult BankAccountPage()
        {
            var res = bankAccount.GetAll();
            //var res = new List<BankAccount>();
            //res.Add(new BankAccount
            //{
            //    AccountNumber = "788768676898989",
            //    Description = "موضوع",
            //    Title = "بانک مسکن",
            //    BranchTitle = "حکیمیه",
            //    ShebaNumber = "97976533234567890987",
            //    AccountOwner = "حسن عباسی",
            //});

            //res.Add(new BankAccount
            //{
            //    AccountNumber = "788768676898989",

            //    Title = "بانک ملی",
            //    BranchTitle = "فرمانیه",
            //    ShebaNumber = "97976533234567890987",
            //    AccountOwner = "حسن منتظری",
            //});

            //res.Add(new BankAccount
            //{
            //    AccountNumber = "788768676898989",

            //    Title = "بانک قوامین",
            //    BranchTitle = "تیر دوقلو",
            //    ShebaNumber = "97976533234567890987",
            //    AccountOwner = "آرمین مرادی",
            //});


            return View(res);
        }
        [Route("certificate")]
        public IActionResult certificate()
        {
            var res = certificate1.GetAll();
            //var res = new List<Certificate>();
            //res.Add(new Certificate { Title = "ایزو9001", Photo = "https://localhost:44323/images/c1.jpg", Description = "استاندارد های بین المللی" });
            //res.Add(new Certificate { Title = "ایزو9002", Photo = "https://localhost:44323/images/c2.jpg", Description = "استاندارد های بین المللی" });
            //res.Add(new Certificate { Title = "ایزو9004", Photo = "https://localhost:44323/images/c3.jpg", Description = "استاندارد های بین المللی" });
            return View(res);
        }
        [Route("faq")]
        public IActionResult faq()
        {
            var res = fAQ.GetAll();
            //var res = new List<FAQ>();
            //res.Add(new FAQ { Question = "سوال در خصوص چگونگی ثبت نام؟", Answer = "پس ورود به اپلیکیشن باید لاگین و رجیستر کنید؟" });
            //res.Add(new FAQ { Question = "سوال در خصوص چگونگی ثبت نام؟", Answer = "پس ورود به اپلیکیشن باید لاگین و رجیستر کنید؟" });
            //res.Add(new FAQ { Question = "سوال در خصوص چگونگی ثبت نام؟", Answer = "پس ورود به اپلیکیشن باید لاگین و رجیستر کنید؟" });
            //res.Add(new FAQ { Question = "سوال در خصوص چگونگی ثبت نام؟", Answer = "پس ورود به اپلیکیشن باید لاگین و رجیستر کنید؟" });
            //res.Add(new FAQ { Question = "سوال در خصوص چگونگی ثبت نام؟", Answer = "پس ورود به اپلیکیشن باید لاگین و رجیستر کنید؟" });
            //res.Add(new FAQ { Question = "سوال در خصوص چگونگی ثبت نام؟", Answer = "پس ورود به اپلیکیشن باید لاگین و رجیستر کنید؟" });
            //res.Add(new FAQ { Question = "سوال در خصوص چگونگی ثبت نام؟", Answer = "پس ورود به اپلیکیشن باید لاگین و رجیستر کنید؟" });
            return View(res);
        }



        [Route("JobAdRequest")]
        public IActionResult JobAdRequest()
        {
            var children = new string[] { "JobAd" };
            var res = jobAdRequest.EntityWithEagerLoad(null, children);
            //var res = jobAdRequest.GetAll();
            //var res = new List<JobAdRequest>();
            //res.Add(new PortalBuilder.Models.JobAdRequest {Id = 1,JobAd = new JobAd { Title = "برنامه نویسی",Description = "تمام وقت و آشنا با معماری میکرو سرویس آشنا با زبان انگلیسی" }});
            //res.Add(new PortalBuilder.Models.JobAdRequest { Id = 2, JobAd = new JobAd { Title = "پشتیبان", Description = " تمام وقت و آشنا با sql آشنا با زبان انگلیسی متعهد و منظم" } });
            //res.Add(new PortalBuilder.Models.JobAdRequest { Id = 3, JobAd = new JobAd { Title = "مهماندار", Description = "تمام وقت و آشنا با تشریفات اداری آشنا با زبان انگلیسی" } });
            return View(res);
        }
        [Route("news")]
        public IActionResult news()
        {
            var res = article.GetAll();

            //var res = new List<Article>();
            //res.Add(new Article{ ViewCount = 1, Writer = "جلیلی",Title = "بورس",Detail = "سهامداران خدیزل بخوانند/آغاز افشای زمین و ساختمان نمادهای بورسیپایان عرضه اولیه کیمیاتک / به هر نفر چند سهم رسید؟آغا عرضه اولیه فجهان / ثبت سفارش تا کی ادامه دارد؟اختلال در کارگزاری‌های بزرگ برای ثبت سفارش عرضه اولیه در سهمیه خرید عرضه اولیه کیمیاتک",Photo = "https://localhost:44323/images/c1.jpg" });
            //res.Add(new Article { ViewCount = 1, Writer = "جلیلی", Title = "بورس", Detail = "سهامداران خدیزل بخوانند/آغاز افشای زمین و ساختمان نمادهای بورسیپایان عرضه اولیه کیمیاتک / به هر نفر چند سهم رسید؟آغا عرضه اولیه فجهان / ثبت سفارش تا کی ادامه دارد؟اختلال در کارگزاری‌های بزرگ برای ثبت سفارش عرضه اولیه در سهمیه خرید عرضه اولیه کیمیاتک", Photo = "https://localhost:44323/images/c1.jpg" });
            //res.Add(new Article { ViewCount = 1, Writer = "جلیلی", Title = "بورس", Detail = "سهامداران خدیزل بخوانند/آغاز افشای زمین و ساختمان نمادهای بورسیپایان عرضه اولیه کیمیاتک / به هر نفر چند سهم رسید؟آغا عرضه اولیه فجهان / ثبت سفارش تا کی ادامه دارد؟اختلال در کارگزاری‌های بزرگ برای ثبت سفارش عرضه اولیه در سهمیه خرید عرضه اولیه کیمیاتک", Photo = "https://localhost:44323/images/c1.jpg" });
            return View(res);
        }

        [Route("contact")]
        public IActionResult contact()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

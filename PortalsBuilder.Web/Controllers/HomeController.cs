using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortalBuilder.Models;
using PortalsBuilder.Web.Models;

namespace PortalsBuilder.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("about")]
        public IActionResult about()
        {
            return View();
        }
        [Route("team")]
        public IActionResult team()
        {
            var res = new List<PortalBuilder.Models.Staff>();
            res.Add(new Staff { Education = "ارشد نرم افزار", FirstName = "سجاد", Phone = "091265456", LastName = "جلیلی", Photo = "https://localhost:44323/images/jil.jpg", StaffPosition = new StaffPosition { Title = "معاونت" }, OrganizationUnit = new OrganizationUnit { Title = "IT" } });

            res.Add(new Staff { Education = "ارشد نرم افزار", FirstName = "احسان", Phone = "091263456", LastName = "سعید پور", Photo = "https://localhost:44323/images/sae.jpg", StaffPosition = new StaffPosition { Title = "معاونت" }, OrganizationUnit = new OrganizationUnit { Title = "IT" } });

            res.Add(new Staff { Education = "ارشد نرم افزار", FirstName = "مجید", Phone = "091263456", LastName = "رمضانی", Photo = "https://localhost:44323/images/maj.jpg", StaffPosition = new StaffPosition { Title = "معاونت" }, OrganizationUnit = new OrganizationUnit { Title = "IT" } });
            res.Add(new Staff { Education = "طراح", FirstName = "رامین", Phone = "091263456", LastName = "مومنی", Photo = "https://localhost:44323/images/sam.jpg", StaffPosition = new StaffPosition { Title = "سمی" }, OrganizationUnit = new OrganizationUnit { Title = "sami" } });
            return View(res);
        }
        [Route("ColleaguesAndCustomers")]
        public IActionResult ColleaguesAndCustomers()
        {
            var res = new List<PortalBuilder.Models.Customer>();
            res.Add(new Customer { FirstName = "محمد", LastName = "موسوی", JobTitle = "کارگذار بورس", Description = "بسیار خوش فکر و بیان ارتباطات. نقاط عطف ، مهلت و کار سریع را پاک کنید. صبر. صبر بی نهایت. بدون میانبر حتی اگر مشتری بی خیال باشد. بهترین قسمت ... همیشه حل مشکلات با ایده های عالی و عالی!." });
            res.Add(new Customer { FirstName = "علی", LastName = "عرفانی", JobTitle = "کارگذار بورس", Description = "بسیار خوش فکر و بیان ارتباطات. نقاط عطف ، مهلت و کار سریع را پاک کنید. صبر. صبر بی نهایت. بدون میانبر حتی اگر مشتری بی خیال باشد. بهترین قسمت ... همیشه حل مشکلات با ایده های عالی و عالی!." });
            res.Add(new Customer { FirstName = "رضا", LastName = "مسعودی", JobTitle = "کارگذار بورس", Description = "بسیار خوش فکر و بیان ارتباطات. نقاط عطف ، مهلت و کار سریع را پاک کنید. صبر. صبر بی نهایت. بدون میانبر حتی اگر مشتری بی خیال باشد. بهترین قسمت ... همیشه حل مشکلات با ایده های عالی و عالی!." });
            res.Add(new Customer { FirstName = "آمنه", LastName = "عبدالهی", JobTitle = "کارگذار بورس", Description = "بسیار خوش فکر و بیان ارتباطات. نقاط عطف ، مهلت و کار سریع را پاک کنید. صبر. صبر بی نهایت. بدون میانبر حتی اگر مشتری بی خیال باشد. بهترین قسمت ... همیشه حل مشکلات با ایده های عالی و عالی!." });
            res.Add(new Customer { FirstName = "روژا", LastName = "کاسبی", JobTitle = "کارگذار بورس", Description = "بسیار خوش فکر و بیان ارتباطات. نقاط عطف ، مهلت و کار سریع را پاک کنید. صبر. صبر بی نهایت. بدون میانبر حتی اگر مشتری بی خیال باشد. بهترین قسمت ... همیشه حل مشکلات با ایده های عالی و عالی!." });
            return View(res);
        }

        [Route("Branch")]
        public IActionResult Branch()
        {
            var res = new List<PortalBuilder.Models.Branch>();
            res.Add(new PortalBuilder.Models.Branch
            {
                Title = "شعبه زعفرانیه",
                ManagerName = "محسن سلامی",
                WorkTimes = "از 8 تا 15"
                ,
                Description = "پرداخت وام",
                Phone = "88284724",
                Email = "kargo@gmail.com",
                Address = "محله زعفرانیه در منطقه‌ی یک شهرداری تهران",
                City = "تهران",
                PostalCode = "23456765",
                Province = new Province { Title = "تهران" }
            });

            res.Add(new PortalBuilder.Models.Branch
            {
                Title = "شعبه مجیدیه",
                ManagerName = "عباس سلامی",
                WorkTimes = "از 8 تا 15"
               ,
                Description = "مشاوره",
                Phone = "44252452",
                Email = "moshavere@gmail.com",
                Address = "محله مجیدیه در منطقه‌ی یک شهرداری تهران",
                City = "تهران",
                PostalCode = "6356363",
                Province = new Province { Title = "تهران" }
            });
            return View(res);
        }



        [Route("SocialMedia")]
        public IActionResult SocialMedia()
        {


            var res = new List<PortalBuilder.Models.Branch>();
            res.Add(new PortalBuilder.Models.Branch
            {
                Title = "شعبه زعفرانیه",
                ManagerName = "محسن سلامی",
                WorkTimes = "از 8 تا 15",
                Photo = "https://localhost:44323/images/download.jpg",
                Description = "پرداخت وام",
                Phone = "88284724",
                Email = "kargo@gmail.com",
                Address = "محله زعفرانیه در منطقه‌ی یک شهرداری تهران",
                City = "تهران",
                PostalCode = "23456765",
                Province = new Province { Title = "تهران" }
            });

            res.Add(new PortalBuilder.Models.Branch
            {
                Title = "شعبه مجیدیه",
                ManagerName = "عباس سلامی",
                WorkTimes = "از 8 تا 15",
                Photo = "https://localhost:44323/images/download.jpg",
                Description = "مشاوره",
                Phone = "44252452",
                Email = "moshavere@gmail.com",
                Address = "محله مجیدیه در منطقه‌ی یک شهرداری تهران",
                City = "تهران",
                PostalCode = "6356363",
                Province = new Province { Title = "تهران" }
            });
            res.Add(new PortalBuilder.Models.Branch
            {
                Title = "شعبه مجیدیه",
                ManagerName = "عباس سلامی",
                WorkTimes = "از 8 تا 15",
                Photo = "https://localhost:44323/images/download2.jpg",
                Description = "مشاوره",
                Phone = "44252452",
                Email = "moshavere@gmail.com",
                Address = "محله مجیدیه در منطقه‌ی یک شهرداری تهران",
                City = "تهران",
                PostalCode = "6356363",
                Province = new Province { Title = "تهران" }
            });
            return View(res);
        }


        [Route("BankAccountPage")]
        public IActionResult BankAccountPage()
        {
            var res = new List<BankAccount>();

            res.Add(new BankAccount
            {
                AccountNumber = "788768676898989",

                Title = "بانک مسکن",
                BranchTitle = "حکیمیه",
                ShebaNumber = "97976533234567890987",
                AccountOwner = "حسن عباسی",
            });

            res.Add(new BankAccount
            {
                AccountNumber = "788768676898989",

                Title = "بانک ملی",
                BranchTitle = "فرمانیه",
                ShebaNumber = "97976533234567890987",
                AccountOwner = "حسن منتظری",
            });

            res.Add(new BankAccount
            {
                AccountNumber = "788768676898989",

                Title = "بانک قوامین",
                BranchTitle = "تیر دوقلو",
                ShebaNumber = "97976533234567890987",
                AccountOwner = "آرمین مرادی",
            });


            return View(res);
        }

        [Route("contact")]
        public IActionResult contact()
        {
            return View();
        }
        [Route("faq")]
        public IActionResult faq()
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

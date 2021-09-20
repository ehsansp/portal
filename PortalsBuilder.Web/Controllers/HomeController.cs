using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PortalBuilder.Core.Services.generic;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.Models;
using PortalsBuilder.Web.Models;

namespace PortalsBuilder.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<HomeController> _logger;
        private ICustomerService _customerService;
        private readonly IGenericRepository<Staff> staff;
        private readonly IGenericRepository<StaffPosition> staffPosition;
        private readonly IGenericRepository<JobAdRequest> jobAdRequest;
        private readonly IGenericRepository<Menu> menu;
        private readonly IGenericRepository<SiteSetting> siteSetting;
        private readonly IGenericRepository<Banner> banner;
        private readonly IGenericRepository<BrandTimeline> brandTimeline;
        private readonly IGenericRepository<JobAd> jobAd;
        private readonly IGenericRepository<Customer> customer;
        private readonly IGenericRepository<Branch> branch;
        private readonly IGenericRepository<BankAccount> bankAccount;
        private readonly IGenericRepository<Certificate> certificate1;
        private readonly IGenericRepository<FAQ> fAQ;
        private readonly IGenericRepository<Article> article;



        //Configuration.GetConnectionString("TopLearnConnection")

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
              IGenericRepository<Banner> banner,
              IGenericRepository<BrandTimeline> brandTimeline,
              IGenericRepository<JobAd> JobAd,
              IConfiguration Configuration


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
            this.brandTimeline = brandTimeline;
            jobAd = JobAd;
            configuration = Configuration;
        }

        public IActionResult Header() 
        {
            return PartialView("Header");
        }
        public IActionResult Footer()
        {
            return PartialView("Footer");
        }

        public IActionResult Head()
        {
            return PartialView("Head");
        }


        public IActionResult Index()
        {
            var res = new siteSettingMenuBannerBrandTimelineVM();
            res.banner.AddRange(banner.GetAll());
            res.brandTimeline.AddRange(brandTimeline.GetAll());
            res.siteSetting= siteSetting.GetAll().FirstOrDefault();
            ViewBag.BaseImageUrl = configuration.GetConnectionString("baseImageUrl");
            return View(res);
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
            return View(customer.GetAll());
        }

        [Route("Branch")]
        public IActionResult Branch()
        {
            return View(branch.GetAll());
        }



        [Route("SocialMedia")]
        public IActionResult SocialMedia()
        {
            var res = branch.GetAll();
            return View(res);
        }
        [Route("BrandTimelines")]
        public IActionResult BrandTimelines()
        {
            return View(brandTimeline.GetAll());
        }

        [Route("BankAccountPage")]
        public IActionResult BankAccountPage()
        {
            return View(bankAccount.GetAll());
        }
        [Route("certificate")]
        public IActionResult certificate()
        {
            return View(certificate1.GetAll());
        }
        [Route("faq")]
        public IActionResult faq()
        {
            return View(fAQ.GetAll());
        }



        [Route("JobAds")]
        public IActionResult JobAdRequest()
        {
            return View(jobAd.GetAll());
        }
        //[Route("JobRequest")]
        //[HttpGet]
        //public IActionResult JobRequest()
        //{
        //    return View(jobAd.GetAll());
        //}
        //[Authorize]
        [Route("JobRequestForm")]
        [HttpGet]
        public IActionResult JobRequestForm(int jobAddId)
        {

            ViewBag.reqId = jobAddId;
            return View(new JobAdRequest());
        }
        [Route("JobRequestForm")]
        [HttpPost]
        public IActionResult JobRequestForm(JobAdRequest input)
        {
            try
            {
                input.CreatedBy = 1;
                input.CreatedAt = DateTime.Now;
                jobAdRequest.Add(input);
                return Redirect("JobAds");
            }
            catch (Exception)
            {

                return Redirect("JobAds");
            }
            
           
        }
        [Route("news")]
        public IActionResult news()
        {
            return View(article.GetAll());
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

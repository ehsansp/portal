using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Context;
using ShahrKoodak.DataLayer.Entities.Slider;

namespace ShahrKoodak.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        private ISliderService _sliderService;
        private IUserService _userService;
        private ShahrContext _context;

        public HomeController(IProductService productService, ISliderService sliderService, IUserService userService, ShahrContext context)
        {
            _productService = productService;
            _sliderService = sliderService;
            _userService = userService;
            _context = context;
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetString("f", "1");
            var popular = _productService.GetPopularProduct();
            ViewBag.PopularCourse = popular;

            var leftBanner = _sliderService.GetLeftBannerById(1);
            ViewBag.leftBannerImage = leftBanner.ImageName;
            ViewBag.leftBannerLinke = leftBanner.BennerLink;

            var rightBanner = _sliderService.GetRightBannerById(1);
            ViewBag.rightBannerImage = rightBanner.ImageName;
            ViewBag.rightBannerLinke = rightBanner.BennerLink;

            var middleBanner = _sliderService.GetMiddleBannerById(1);
            ViewBag.middleBannerImage = middleBanner.ImageName;
            ViewBag.middleBannerLinke = middleBanner.BennerLink;

            var art = _userService.GetArticle().Item1;
            ViewBag.arti = art;

            var leftBanner2 = _sliderService.GetLeftBanner2ById(1);
            ViewBag.leftBanner2Image = leftBanner2.ImageName;
            ViewBag.leftBanner2Linke = leftBanner2.BennerLink;

            var rightBanner2 = _sliderService.GetRightBanner2ById(1);
            ViewBag.rightBanner2Image = rightBanner2.ImageName;
            ViewBag.rightBanner2Linke = rightBanner2.BennerLink;

            var group = _productService.GetGroupForManageProduct();
            ViewData["group"] = new SelectList(group, "Value", "Text");

            var sub = _productService.GetSubGroupForManageCourse(int.Parse(group.First().Value));
            ViewData["sub"] = new SelectList(sub, "Value", "Text");

            return View(_productService.GetProduct().Item1);
        }
        public IActionResult GetSubGroups(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "انتخاب کنید", Value = "0"}
            };
            list.AddRange(_productService.GetSubGroupForManageCourse(id));
            return Json(new SelectList(list, "Value", "Text"));
        }

        public IActionResult GetSubGroups2(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "لطفا نام محله را انتخاب کنید", Value = "0"}
            };
            list.AddRange(_productService.GetOstanForManageCourse(id));
            if (list.Count == 1)
            {
                List<SelectListItem> list2 = new List<SelectListItem>()
                {
                    new SelectListItem() {Text = "بدون محله", Value = "0"}

                };
                return Json(new SelectList(list2, "Value", "Text"));
            }
            return Json(new SelectList(list, "Value", "Text"));
        }

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("Contact")]
        public IActionResult Contact(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
            ViewBag.IsSuccess = true;
            return View();
        }

        [Route("Cash")]
        public IActionResult Cash()
        {
            return View();
        }
        [Route("Gold")]
        public IActionResult Gold()
        {
            return View();
        }
        [Route("Chek")]
        public IActionResult Chek()
        {
            return View();
        }
        [Route("AccountDetail")]
        public IActionResult AccountDetail()
        {
            return View();
        }
        [Route("Store")]
        public IActionResult Store()
        {
            return View();
        }
        [Route("OnlinePayment/{id}")]
        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];


                var payment = new Zarinpal.Payment("87d6f25e-7c10-11ea-a66a-000c295eb8fc", 5000);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    ViewBag.code = res.RefId;
                    ViewBag.IsSuccess = true;
                }

            }

            return View();

        }
    }
}
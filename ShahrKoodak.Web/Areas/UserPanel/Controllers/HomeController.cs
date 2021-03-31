using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Jeeb.Client.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ShahrKoodak.Core.common;
using ShahrKoodak.Core.DTOs.User;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Entities.User;
using ShahrKoodak.DataLayer.Entities.Wallet;
using ShahrKoodak.Web.Models;
using ShahrKoodak.Web.Settings;
using ShahrKoodak.Web.Utils;

namespace ShahrKoodak.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IProductService _productService;
        private readonly AppSetting _appSetting;
        private readonly JeebSetting _jeebSetting;
        private IJeebPaymentClient _paymentClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IUserService userService, IProductService productService, IOptions<AppSetting> appOptions, IOptions<JeebSetting> jeebOptions, IJeebPaymentClient paymentClient, ILogger<HomeController> logger)
        {
            _userService = userService;
            _productService = productService;
            _appSetting = appOptions.Value;
            _jeebSetting = jeebOptions.Value;
            _paymentClient = paymentClient;
            _logger = logger;
        }
        
        public async Task<IActionResult> Index()
        {
            ViewData["UserAvatar"] = _userService.GetUserByUserName(User.Identity.Name).UserAvatar;
            ViewData["Name"] = _userService.GetUserByUserName(User.Identity.Name).Name + ' ' +
                               _userService.GetUserByUserName(User.Identity.Name).Family;



            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";

            var client = new HttpClient();

            var uri = new Uri(url);
            var result = await client.GetStringAsync(uri);


            int index = result.IndexOf("&#36;");
            index = index + 15;
            string s = result.Substring(index, 11);
            s = s.Remove(2,1);
            ViewBag.ee = s;




            string url2 = "https://min-api.cryptocompare.com/data/price?fsym=eth&tsyms=USD,JPY,EUR";
            var client2 = new HttpClient();

            var uri2 = new Uri(url2);
            var result2 = await client.GetStringAsync(uri2);

            int index2 = result2.IndexOf("USD");
            index2 = index2 + 5;
            string ss = result2.Substring(index2, 7);
            ViewBag.ss = ss;


            string url3 = "https://min-api.cryptocompare.com/data/price?fsym=doge&tsyms=USD,JPY,EUR";
            var client3 = new HttpClient();

            var uri3 = new Uri(url3);
            var result3 = await client.GetStringAsync(uri3);

            int index3 = result3.IndexOf("USD");
            index3 = index3 + 5;
            string doge = result3.Substring(index3, 7);
            ViewBag.doge = doge;


            ViewData["Wallet"] = _userService.GetUserInformation(User.Identity.Name).Wallet;
            ViewData["btc"] = _userService.GetUserInformation(User.Identity.Name).btc;
            ViewData["eth"] = _userService.GetUserInformation(User.Identity.Name).eth;
            ViewData["doge"] = _userService.GetUserInformation(User.Identity.Name).doge;
            ViewData["number"] = _userService.GetUserIdByUserName(User.Identity.Name);

            return View();
        }

        [Route("UserPanel/Feed")]
        public IActionResult Feed()
        {
            ViewData["UserAvatar"] = _userService.GetUserByUserName(User.Identity.Name).UserAvatar;
            ViewData["Name"] = _userService.GetUserByUserName(User.Identity.Name).Name + ' ' +
                               _userService.GetUserByUserName(User.Identity.Name).Family;

            return View();
        }

        [Route("UserPanel/Profile")]
        public IActionResult Profile()
        {
            ViewData["UserAvatar"] = _userService.GetUserByUserName(User.Identity.Name).UserAvatar;
            ViewData["Name"] = _userService.GetUserByUserName(User.Identity.Name).Name + ' ' +
                               _userService.GetUserByUserName(User.Identity.Name).Family;

            var user = _userService.GetUserInformation(User.Identity.Name);
            ViewData["Wallet"] = _userService.GetUserInformation(User.Identity.Name).Wallet;
            ViewData["btc"] = _userService.GetUserInformation(User.Identity.Name).btc;
            ViewData["eth"] = _userService.GetUserInformation(User.Identity.Name).eth;
            ViewData["doge"] = _userService.GetUserInformation(User.Identity.Name).doge;
            return View(user);
        }

        [HttpPost]
        [Route("UserPanel/Profile")]
        public IActionResult Profile(InformationUserViewModel user)
        {
            ViewData["UserAvatar"] = _userService.GetUserByUserName(User.Identity.Name).UserAvatar;
            ViewData["Name"] = _userService.GetUserByUserName(User.Identity.Name).Name + ' ' +
                               _userService.GetUserByUserName(User.Identity.Name).Family;

            _userService.EditProfile(User.Identity.Name,user);
            ViewData["Wallet"] = _userService.GetUserInformation(User.Identity.Name).Wallet;
            ViewData["btc"] = _userService.GetUserInformation(User.Identity.Name).btc;
            ViewData["eth"] = _userService.GetUserInformation(User.Identity.Name).eth;
            ViewData["doge"] = _userService.GetUserInformation(User.Identity.Name).doge;
            return View(user);
        }

        [Route("UserPanel/Message")]
        public IActionResult Message()
        {
            ViewData["UserAvatar"] = _userService.GetUserByUserName(User.Identity.Name).UserAvatar;
            ViewData["Name"] = _userService.GetUserByUserName(User.Identity.Name).Name + ' ' +
                               _userService.GetUserByUserName(User.Identity.Name).Family;
            ViewData["Wallet"] = _userService.GetUserInformation(User.Identity.Name).Wallet;
            ViewData["btc"] = _userService.GetUserInformation(User.Identity.Name).btc;
            ViewData["eth"] = _userService.GetUserInformation(User.Identity.Name).eth;
            ViewData["doge"] = _userService.GetUserInformation(User.Identity.Name).doge;
            return View();
        }

        [Route("UserPanel/Password")]
        public IActionResult Password()
        {
            ViewData["UserAvatar"] = _userService.GetUserByUserName(User.Identity.Name).UserAvatar;
            ViewData["Name"] = _userService.GetUserByUserName(User.Identity.Name).Name + ' ' +
                               _userService.GetUserByUserName(User.Identity.Name).Family;
            ViewData["Wallet"] = _userService.GetUserInformation(User.Identity.Name).Wallet;
            ViewData["btc"] = _userService.GetUserInformation(User.Identity.Name).btc;
            ViewData["eth"] = _userService.GetUserInformation(User.Identity.Name).eth;
            ViewData["doge"] = _userService.GetUserInformation(User.Identity.Name).doge;
            return View();
        }

        [HttpPost]
        [Route("UserPanel/Password")]
        public IActionResult Password(UsersViewModel.ChangePassword req)
        {
            if (!ModelState.IsValid)
                return View(req);

            ViewData["Wallet"] = _userService.GetUserInformation(User.Identity.Name).Wallet;
            ViewData["btc"] = _userService.GetUserInformation(User.Identity.Name).btc;
            ViewData["eth"] = _userService.GetUserInformation(User.Identity.Name).eth;
            ViewData["doge"] = _userService.GetUserInformation(User.Identity.Name).doge;
            User user = new User();
            user = _userService.GetUserByUserName(User.Identity.Name);

            _userService.ChangeUserPassword(user.UserName, req.Password);
            ViewBag.IsActive = true;
            return View();
        }

        [Route("UserPanel/Listing")]
        public IActionResult Listing()
        {
            ViewData["UserAvatar"] = _userService.GetUserByUserName(User.Identity.Name).UserAvatar;
            ViewData["Name"] = _userService.GetUserByUserName(User.Identity.Name).Name + ' ' +
                               _userService.GetUserByUserName(User.Identity.Name).Family;
            ViewData["Wallet"] = _userService.GetUserInformation(User.Identity.Name).Wallet;
            ViewData["btc"] = _userService.GetUserInformation(User.Identity.Name).btc;
            ViewData["eth"] = _userService.GetUserInformation(User.Identity.Name).eth;
            ViewData["doge"] = _userService.GetUserInformation(User.Identity.Name).doge;
            return View(_productService.GetProductByUserId(User.Identity.Name));
        }

        [Route("UserPanel/Booking")]
        public IActionResult Booking()
        {
            ViewData["UserAvatar"] = _userService.GetUserByUserName(User.Identity.Name).UserAvatar;
            ViewData["Name"] = _userService.GetUserByUserName(User.Identity.Name).Name + ' ' +
                               _userService.GetUserByUserName(User.Identity.Name).Family;
            ViewData["Wallet"] = _userService.GetUserInformation(User.Identity.Name).Wallet;
            ViewData["btc"] = _userService.GetUserInformation(User.Identity.Name).btc;
            ViewData["eth"] = _userService.GetUserInformation(User.Identity.Name).eth;
            ViewData["doge"] = _userService.GetUserInformation(User.Identity.Name).doge;
            return View();
        }

        [Route("UserPanel/Reviewing")]
        public IActionResult Reviewing()
        {
            ViewData["UserAvatar"] = _userService.GetUserByUserName(User.Identity.Name).UserAvatar;
            ViewData["Name"] = _userService.GetUserByUserName(User.Identity.Name).Name + ' ' +
                               _userService.GetUserByUserName(User.Identity.Name).Family;
            ViewData["Wallet"] = _userService.GetUserInformation(User.Identity.Name).Wallet;
            ViewData["btc"] = _userService.GetUserInformation(User.Identity.Name).btc;
            ViewData["eth"] = _userService.GetUserInformation(User.Identity.Name).eth;
            ViewData["doge"] = _userService.GetUserInformation(User.Identity.Name).doge;
            return View();
        }

        [Route("UserPanel/Add")]
        public IActionResult Add()
        {
            ViewData["UserAvatar"] = _userService.GetUserByUserName(User.Identity.Name).UserAvatar;
            ViewData["Name"] = _userService.GetUserByUserName(User.Identity.Name).Name + ' ' +
                               _userService.GetUserByUserName(User.Identity.Name).Family;

            var group = _productService.GetGroupForManageProduct();
            ViewData["group"] = new SelectList(group, "Value", "Text");

            var sub = _productService.GetSubGroupForManageCourse(int.Parse(group.First().Value));
            ViewData["sub"] = new SelectList(sub, "Value", "Text");
            ViewData["Wallet"] = _userService.GetUserInformation(User.Identity.Name).Wallet;
            ViewData["btc"] = _userService.GetUserInformation(User.Identity.Name).btc;
            ViewData["eth"] = _userService.GetUserInformation(User.Identity.Name).eth;
            ViewData["doge"] = _userService.GetUserInformation(User.Identity.Name).doge;
            return View();
        }

        [HttpPost]
        [Route("UserPanel/Add")]
        public IActionResult Add(InformationAdViewModel profile)
        {
            ViewData["Wallet"] = _userService.GetUserInformation(User.Identity.Name).Wallet;
            ViewData["btc"] = _userService.GetUserInformation(User.Identity.Name).btc;
            ViewData["eth"] = _userService.GetUserInformation(User.Identity.Name).eth;
            ViewData["doge"] = _userService.GetUserInformation(User.Identity.Name).doge;
            _productService.AddAd(User.Identity.Name,profile);
            return Redirect("/UserPanel");
        }

        [Route("UserPanel/Money")]
        public IActionResult Money()
        {
            ViewData["UserAvatar"] = _userService.GetUserByUserName(User.Identity.Name).UserAvatar;
            ViewData["Name"] = _userService.GetUserByUserName(User.Identity.Name).Name + ' ' +
                               _userService.GetUserByUserName(User.Identity.Name).Family;

            ViewData["Wallet"] = _userService.GetUserInformation(User.Identity.Name).Wallet;
            ViewData["btc"] = _userService.GetUserInformation(User.Identity.Name).btc;
            ViewData["eth"] = _userService.GetUserInformation(User.Identity.Name).eth;
            ViewData["doge"] = _userService.GetUserInformation(User.Identity.Name).doge;
            ViewBag.userId = _userService.GetUserIdByUserName(User.Identity.Name);
            return View();
        }

        [Route("UserPanel/Deposit")]
        public IActionResult Deposit()
        {
            ViewData["UserAvatar"] = _userService.GetUserByUserName(User.Identity.Name).UserAvatar;
            ViewData["Name"] = _userService.GetUserByUserName(User.Identity.Name).Name + ' ' +
                               _userService.GetUserByUserName(User.Identity.Name).Family;

            ViewData["Wallet"] = _userService.GetUserInformation(User.Identity.Name).Wallet;
            ViewData["btc"] = _userService.GetUserInformation(User.Identity.Name).btc;
            ViewData["eth"] = _userService.GetUserInformation(User.Identity.Name).eth;
            ViewData["doge"] = _userService.GetUserInformation(User.Identity.Name).doge;

            var model = new IssueViewModel();
            ViewBag.BaseCurrencies = BaseCurrencies;
            ViewBag.Languages = Languages;
            return View(model);
        }

        [Route("UserPanel/Deposit")]
        [HttpPost]
        public IActionResult Deposit([FromForm] IssueViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var model = new IssueViewModel();
                ViewBag.BaseCurrencies = BaseCurrencies;
                ViewBag.Languages = Languages;
                return View(model);
            }

            var dto = MapToIssueDto(viewModel);
            var payment = _paymentClient.Issue(dto);
            var url = _paymentClient.GetRedirectUrl(payment.Token);
            return Redirect(url);
        }

        [Route("UserPanel/Withdrawal")]
        public IActionResult Withdrawal()
        {
            ViewData["UserAvatar"] = _userService.GetUserByUserName(User.Identity.Name).UserAvatar;
            ViewData["Name"] = _userService.GetUserByUserName(User.Identity.Name).Name + ' ' +
                               _userService.GetUserByUserName(User.Identity.Name).Family;

            ViewData["Wallet"] = _userService.GetUserInformation(User.Identity.Name).Wallet;
            ViewData["btc"] = _userService.GetUserInformation(User.Identity.Name).btc;
            ViewData["eth"] = _userService.GetUserInformation(User.Identity.Name).eth;
            ViewData["doge"] = _userService.GetUserInformation(User.Identity.Name).doge;

            var levels = _userService.getWithdrawalTypes();
            ViewData["Levels"] = new SelectList(levels, "Value", "Text");

            var currency = _userService.getCurrency();
            ViewData["currency"] = new SelectList(currency, "Value", "Text");

            return View();
        }

        [Route("UserPanel/Withdrawal")]
        [HttpPost]
        public IActionResult Withdrawal(Withdrawal withdrawal)
        {
            var levels = _userService.getWithdrawalTypes();
            ViewData["Levels"] = new SelectList(levels, "Value", "Text");

            withdrawal.UserId = _userService.GetUserIdByUserName(User.Identity.Name);

            

            _userService.AddWithdrawal(withdrawal);
            ViewBag.flag = true;

            return View();
        }

        [Route("UserPanel/Exchange")]
        public IActionResult Exchange()
        {
            ViewData["UserAvatar"] = _userService.GetUserByUserName(User.Identity.Name).UserAvatar;
            ViewData["Name"] = _userService.GetUserByUserName(User.Identity.Name).Name + ' ' +
                               _userService.GetUserByUserName(User.Identity.Name).Family;

            ViewData["Wallet"] = _userService.GetUserInformation(User.Identity.Name).Wallet;
            ViewData["btc"] = _userService.GetUserInformation(User.Identity.Name).btc;
            ViewData["eth"] = _userService.GetUserInformation(User.Identity.Name).eth;
            ViewData["doge"] = _userService.GetUserInformation(User.Identity.Name).doge;

           

            var levels = _userService.getToCurrency();
            ViewData["To"] = new SelectList(levels, "Value", "Text");

            return View();
        }

        [Route("UserPanel/Exchange")]
        [HttpPost]
        public IActionResult Exchange(Exchange exchange)
        {
            

            var levels = _userService.getToCurrency();
            ViewData["To"] = new SelectList(levels, "Value", "Text");

            exchange.UserId = _userService.GetUserIdByUserName(User.Identity.Name);

            string s = HttpContext.Request.Form["arz"];
            if (s == "two")
            {
                exchange.tousdt = true;
            }

            _userService.AddExchange(exchange);
            ViewBag.flag = true;
            return View();
        }



        #region Statics

        private static readonly List<SelectListItem> BaseCurrencies = new List<SelectListItem>()
        {
            new SelectListItem("Bitcoin", "BTC"),
            new SelectListItem("Iranian Rials", "IRR"),
            new SelectListItem("Iranian Toman", "IRT"),
            new SelectListItem("US Dollar", "USD"),
            new SelectListItem("Pond", "GBP"),
            new SelectListItem("Euro", "EUR"),
            new SelectListItem("Australian Dollar", "AUD"),
            new SelectListItem("Canadian Dollar", "CAD")
        };

        private static readonly List<SelectListItem> Languages = new List<SelectListItem>()
        {
            new SelectListItem("Auto", null),
            new SelectListItem("Farsi", "fa"),
            new SelectListItem("English", "en")
        };


        private IssueDto MapToIssueDto(IssueViewModel viewModel)
        {
            var orderNo = RandomTools.GetUniqueKey(10);
            var dto = new IssueDto
            {
                Type = viewModel.Type,
                Mode = viewModel.Mode,
                Client = viewModel.Client,

                OrderNo = orderNo,
                Language = viewModel.Language,
                PayableCoins = viewModel.PayableCoins,

                CallbackUrl = GetSecureCallbackUrl(orderNo),
                WebhookUrl = GetSecureWebhookUrl(orderNo),

                AllowReject = viewModel.AllowReject,
                AllowTestNets = viewModel.AllowTestNets
            };

            if (viewModel.Type == Constants.PaymentType.Restricted)
            {
                dto.BaseAmount = viewModel.BaseAmount;
                dto.BaseCurrencyId = viewModel.BaseCurrencyId;
            }

            if (dto.Language?.ToLower() == "auto")
            {
                dto.Language = null;
            }

            return dto;
        }

        private string GetSecureCallbackUrl(string orderNo)
        {
            var hash = SecurityTools.CalculatePaymentHash(_jeebSetting.ApiKey, orderNo);
            var builder = new UriBuilder(_appSetting.ServerRootAddress) { Path = "Callback", Query = $"hash={hash}" };
            return builder.ToString();
        }

        private string GetSecureWebhookUrl(string orderNo)
        {
            var hash = SecurityTools.CalculatePaymentHash(_jeebSetting.ApiKey, orderNo);
            var builder = new UriBuilder(_appSetting.ServerRootAddress) { Path = "Webhook", Query = $"hash={hash}" };
            return builder.ToString();
        }


        #endregion
    }
}
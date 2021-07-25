using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;
using ShahrKoodak.Core.Convertors;
using ShahrKoodak.Core.DTOs;
using ShahrKoodak.Core.DTOs.Product;
using ShahrKoodak.Core.DTOs.User;
using ShahrKoodak.Core.Generator;
using ShahrKoodak.Core.Security;
using ShahrKoodak.Core.Senders;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Context;
using ShahrKoodak.DataLayer.Entities.Product;
using ShahrKoodak.DataLayer.Entities.User;
using ShahrKoodak.DataLayer.Entities.Wallet;
using ShahrKoodak.Web.Auth;
using ShahrKoodak.Web.Pages.Admin.Users;

namespace ShahrKoodak.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private ShahrContext _context;
        private IViewRenderService _viewRender;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(IUserService userService, ShahrContext context, IViewRenderService viewRender, SignInManager<ApplicationUser> signInManager)
        {
            _userService = userService;
            _context = context;
            _viewRender = viewRender;
            _signInManager = signInManager;
        }

        [Route("city")]
        public async Task<IActionResult> city()
        {
            for (int j = 1; j < 9; j++)
            {



                string url = "https://api.divar.ir/v5/places/cities/"+j+"/districts";

                var client = new HttpClient();

                var uri = new Uri(url);
                var result = await client.GetStringAsync(uri);
                int index = result.IndexOf('[');
                int indexof = result.IndexOf(']');
                result = result.Replace("\"neighbors\":[],", "");
                result = result.Replace(",\"tags\":[]", "");
                bool flag = true;


                while (flag)
                {
                    flag = result.Contains("centroid");
                    if (flag)
                    {
                        int startWord = 0;
                        int endWord = 0;
                        bool g = false;
                        int count = 0;
                        startWord = result.IndexOf("centroid", 0);
                        endWord = startWord;

                        endWord = result.IndexOf('}', startWord);



                        result = result.Remove(startWord - 2, (endWord - startWord) + 3);
                    }

                }

                result = result.Replace("new", "news");
                string s = "";
                for (int i = index; i <= result.Length - 2; i++)
                {
                    s = s + result[i];
                }

                //int y = s.IndexOf("top_cities", 0);
                //s = s.Remove(y - 2, (s.Length - y)+2);
                s = s.Replace(",\"tags\":[]", "");

                var newresult = JsonConvert.DeserializeObject<List<CityVM>>(s);

                foreach (var item in newresult)
                {
                    Shahr c = new Shahr();
                    c.ShahrId = item.id;
                    c.GroupTitle = item.name;
                    c.IsDelete = false;
                    c.ParentId = j;
                    c.slug = item.slug;

                    _context.Add(c);
                    _context.SaveChanges();
                }
            }

            return View();
        }


        #region Login

        [Route("Login")]
        public ActionResult Login(bool EditProfile = false)
        {
            ViewBag.EditProfile = EditProfile;
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginViewModel login)
        {
            login.Email = ConvertNumber.PersianToEnglish(login.Email);
            var user = _userService.LoginUser(login);
            var user2 = _userService.GetUserByUserName(login.Email);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };
                    HttpContext.SignInAsync(principal, properties);

                    ViewBag.IsSuccess = true;

                    return View();
                }
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری شما فعال نمی باشد.");
                }
            }

            if (user2 == null)
            {
                ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد.");
            }
            else
            {
                ModelState.AddModelError("Email", "رمز عبور شما اشتباه است.");
            }

            return View(login);
        }

        #endregion


        #region Register


        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register, SendSMS.Asp.Net.Core.Models.SendSms_RequestModel req)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            register.UserName = ConvertNumber.PersianToEnglish(register.Email);

            Random rnd = new Random();
            string r = "";
            string rr = "";

            if (_userService.IsExistUserName(register.Email))
            {

                // r = rnd.Next(1000, 9999).ToString();
                // UsersViewModel.EditUserViewModel user2 = new UsersViewModel.EditUserViewModel();

                // user2.UserId = _userService.GetUserIdByUserName(register.Email);
                // user2.ActiveCode = r;
                // user2.Email = register.Email;

                //_userService.EditUserFromAdmin(user2);
                //#region Send Activation Email

                // rr = "به ری20 خوش آمدید. کد فعال سازی شما: " + r;

                //var api = await new ServiceReference1.SendSMSSoapClient(new ServiceReference1.SendSMSSoapClient.EndpointConfiguration() { }).SendAsync("FCA2AA2E-F69E-4130-BB73-167F96719CFA", register.Email, rr, "");
                //ViewBag.SendResult = api.Body.SendResult;
                //ViewBag.retStr = api.Body.retStr;
                ////string body = _viewRender.RenderToStringAsync("_ActiveEmail", user);
                ////SendEmail.Send(user.Email, "فعالسازی", body);

                //#endregion

                //return View("Active");
                ModelState.AddModelError("UserName", "شماره همراه قبلا در سیستم ثبت شده است.");
                return View(register);
            }

            r = rnd.Next(1000, 9999).ToString();
            DataLayer.Entities.User.User user = new User()
            {
                ActiveCode = r,
                Email = register.Email,
                Password = r,
                RegisterDate = DateTime.Now,
                UserAvatar = "Default.jpg",
                CityId = 1,
                UserName = register.Email

            };
            _userService.AddUser(user);

            #region Send Activation Email

            rr = "به بابیت خوش آمدید. کد فعال سازی شما: " + r;

            var api2 = await new ServiceReference1.SendSMSSoapClient(new ServiceReference1.SendSMSSoapClient.EndpointConfiguration() { }).SendAsync("FCA2AA2E-F69E-4130-BB73-167F96719CFA", register.Email, rr, "");
            ViewBag.SendResult = api2.Body.SendResult;
            ViewBag.retStr = api2.Body.retStr;
            //string body = _viewRender.RenderToStringAsync("_ActiveEmail", user);
            //SendEmail.Send(user.Email, "فعالسازی", body);

            #endregion

            return View("Active");
        }

        #endregion

        #region Active

        [Route("Active")]
        public IActionResult Active()
        {
            return View();
        }

        [Route("Active")]
        [HttpPost]
        public IActionResult Active(UsersViewModel.ActiveViewModel req)
        {
            User user = new User();
            string m = MyExtensions.PersianToEnglish(req.code);
            user = _userService.GetUserByActiveCode(m);

            if (user == null)
            {
                ModelState.AddModelError("UserName", "کد وارد شده صحیح نمی باشد.");
                return View("Active");
            }

            ViewBag.IsActive = _userService.ActiveAcount(m);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.UserName)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = true
            };
            HttpContext.SignInAsync(principal, properties);

            ViewBag.IsSuccess = true;
            return Redirect("/SetPassword");
        }

        #endregion

        #region Logout

        [

            Route("Logout")]

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }

        #endregion

        #region SetPassword

        [Route("SetPassword")]
        public IActionResult SetPassword()
        {
            return View();
        }

        [Route("SetPassword")]
        [HttpPost]
        public IActionResult SetPassword(UsersViewModel.PasswordViewModel req)
        {
            if (!ModelState.IsValid)
                return View(req);


            User user = new User();
            user = _userService.GetUserByUserName(User.Identity.Name);

            _userService.ChangeUserPassword(user.UserName, req.Password);
            ViewBag.IsActive = true;
            return Redirect("/Referal");
        }

        #region Referal

        [Route("Referal")]
        public IActionResult Referal()
        {
            User user = _context.Users.FirstOrDefault(c => c.UserName == User.Identity.Name);
            if (user.Referal)
            {
                return Redirect("/UserPanel");
            }
            return View();

        }

        [Route("Referal")]
        [HttpPost]
        public IActionResult Referal(UsersViewModel.ReferalViewModel req)
        {
            if (!ModelState.IsValid)
                return View(req);

            bool UserFind = _context.Users.Any(c => c.UserId == req.UserId);

            if (UserFind)
            {
                Wallet wallet = new Wallet();
                wallet.Amount = Convert.ToDecimal("0.5");
                wallet.CreateDate = DateTime.Now;
                wallet.Description = "ریفرال";
                wallet.IsPay = true;
                wallet.TypeId = 1;
                wallet.UserId = req.UserId;
                _context.Add(wallet);
                _context.SaveChanges();

                User user = _context.Users.FirstOrDefault(c => c.UserName == User.Identity.Name);
                user.Referal = true;
                _context.Update(user);
                _context.SaveChanges();

                return Redirect("/UserPanel");
            }

            ModelState.AddModelError("UserName", "شماره ریفرال اشتباه است.");
            return View(req);

        }

        #endregion

        #endregion

        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("ForgotPassword")]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel req)
        {
            if (!ModelState.IsValid)
                return View(req);

            User user = new User();
            req.Email = ConvertNumber.PersianToEnglish(req.Email);

            user = _userService.GetUserByUserName(req.Email);

            if (user == null)
            {
                ModelState.AddModelError("Email", "این شماره قبلا در سیستم ثبت نشده است.");
                return View(req);
            }



            Random rnd = new Random();
            string r = "";
            string rr = "";

            r = rnd.Next(1000, 9999).ToString();

            user.ActiveCode = r;
            _context.Update(user);
            _context.SaveChanges();



            #region Send Activation Email

            rr = "به بابیت خوش آمدید. کد فعالسازی شما: " + r;

            var api2 = await new ServiceReference1.SendSMSSoapClient(new ServiceReference1.SendSMSSoapClient.EndpointConfiguration() { }).SendAsync("FCA2AA2E-F69E-4130-BB73-167F96719CFA", user.UserName, rr, "");
            ViewBag.SendResult = api2.Body.SendResult;
            ViewBag.retStr = api2.Body.retStr;

            #endregion

            return View("Active");
        }

        #region Google

        [Route("provider/{provider}")]
        public IActionResult GetProvider(string provider)
        {
            var redirectUtl = Url.RouteUrl("ExternalLogin", Request.Scheme);

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUtl);

            return Challenge(properties, provider);
        }

        [Route("external-login", Name = "ExternalLogin")]
        public IActionResult ExternalLogin()
        {

            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var name = User.FindFirstValue(ClaimTypes.Name);


            var user = _context.Users.SingleOrDefault(s => s.Email == userEmail || s.UserName == userEmail);

            if (user != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);

                ViewBag.IsSuccess = true;

            }
            else
            {



                DataLayer.Entities.User.User user2 = new User()
                {
                    ActiveCode = NameGenerator.GenerateUniqeCode(),
                    Password = PasswordHelper.EncodePasswordMd5(NameGenerator.GenerateUniqeCode()),
                    RegisterDate = DateTime.Now,
                    UserAvatar = "Default.jpg",
                    CityId = 1,
                    UserName = userEmail,
                    Email = userEmail,
                    Name = name,
                    Family = name
                };

                _userService.AddUser(user2);

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user2.UserId.ToString()),
                    new Claim(ClaimTypes.Name,user2.UserName)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);

                ViewBag.IsSuccess = true;
            }

            return Redirect("/");
        }

        #endregion

    }
}
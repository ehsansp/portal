using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShahrKoodak.Core.Convertors;
using ShahrKoodak.Core.DTOs;
using ShahrKoodak.Core.DTOs.Store;
using ShahrKoodak.Core.DTOs.User;
using ShahrKoodak.Core.Generator;
using ShahrKoodak.Core.Security;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Context;
using ShahrKoodak.DataLayer.Entities.User;
using ShahrKoodak.DataLayer.Entities.Wallet;

namespace ShahrKoodak.Core.Services
{
    public class UserService : IUserService
    {
        private ShahrContext _context;

        public UserService(ShahrContext context)
        {
            _context = context;
        }

        public bool ActiveAcount(string activeCode)
        {
            var user = _context.Users.SingleOrDefault((u => u.ActiveCode == activeCode));
            if (user == null || user.IsActive)
            {
                user.ActiveCode = NameGenerator.GenerateUniqeCode();
                _context.SaveChanges();
                return true;
            }

            Store addStore=new Store();
            addStore.UserId = user.UserId;
            addStore.GroupId = 1;
            addStore.SubGroup = 10;
            addStore.Banner = "store-banner.jpg";
            addStore.Logo = "store10.png";
            _context.Stores.Add(addStore);
            _context.SaveChanges();
            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUniqeCode();
            _context.SaveChanges();
            Wallet wallet = new Wallet();
            wallet.Amount = Convert.ToDecimal("0.5");
            wallet.CreateDate=DateTime.Now;
            wallet.Description = "ثبت نام";
            wallet.IsPay = true;
            wallet.TypeId = 1;
            wallet.UserId = user.UserId;
            _context.Add(wallet);
            _context.SaveChanges();
            return true;
        }

        public int AddStore(Store store)
        {
            _context.Stores.Add(store);
            _context.SaveChanges();
            return store.StoreId;
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        

        public int AddUserFromAdmin(UsersViewModel.CreateUserViewModel user)
        {
            User addUser = new User();
            addUser.Password = PasswordHelper.EncodePasswordMd5(user.Password);
            addUser.ActiveCode = NameGenerator.GenerateUniqeCode();
            addUser.Email = user.Email;
            addUser.IsActive = true;
            addUser.RegisterDate = DateTime.Now;
            addUser.UserName = user.UserName;

            #region Save Avatar

            if (user.UserAvatar != null)
            {
                string imagePath = "";


                addUser.UserAvatar = NameGenerator.GenerateUniqeCode() + Path.GetExtension(user.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", addUser.UserAvatar);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    user.UserAvatar.CopyTo(stream);
                }
            }

            #endregion

            return AddUser(addUser);
        }

        public decimal BalanceUserWallet(string userName)
        {
            int userId = GetUserIdByUserName(userName);

            var enter = _context.Wallets.Where(w => w.UserId == userId && w.TypeId == 1 && w.IsPay).Select(w => w.Amount)
                .ToList();

            var exit = _context.Wallets.Where(w => w.UserId == userId && w.TypeId == 2 && w.IsPay).Select(w => w.Amount)
                .ToList();

            return (enter.Sum() - exit.Sum());
        }

        public decimal Balancebtc(string userName)
        {
            int userId = GetUserIdByUserName(userName);

            var enter = _context.Wallets.Where(w => w.UserId == userId && w.TypeId == 1 && w.IsPay).Select(w => w.btc)
                .ToList();

            var exit = _context.Wallets.Where(w => w.UserId == userId && w.TypeId == 2 && w.IsPay).Select(w => w.btc)
                .ToList();

            return (enter.Sum() - exit.Sum());
        }

        public decimal Balancedoge(string userName)
        {
            int userId = GetUserIdByUserName(userName);

            var enter = _context.Wallets.Where(w => w.UserId == userId && w.TypeId == 1 && w.IsPay).Select(w => w.doge)
                .ToList();

            var exit = _context.Wallets.Where(w => w.UserId == userId && w.TypeId == 2 && w.IsPay).Select(w => w.doge)
                .ToList();

            return (enter.Sum() - exit.Sum());
        }

        public decimal Balanceeth(string userName)
        {
            int userId = GetUserIdByUserName(userName);

            var enter = _context.Wallets.Where(w => w.UserId == userId && w.TypeId == 1 && w.IsPay).Select(w => w.eth)
                .ToList();

            var exit = _context.Wallets.Where(w => w.UserId == userId && w.TypeId == 2 && w.IsPay).Select(w => w.eth)
                .ToList();

            return (enter.Sum() - exit.Sum());
        }

        public void DeleteUser(int userId)
        {
            User user = getUserById(userId);
            user.IsDelete = true;
            UpdateUser(user);
        }

        public void EditProfile(string username, InformationUserViewModel profile)
        {
            var user = GetUserByUserName(username);
            user.UserName = username;
            user.Family = profile.Family;
            user.Mail = profile.Mail;
            user.Tel = profile.Tel;
            user.WhatsApp = profile.WhatsApp;
            user.WebSite = profile.WebSite;
            user.CityId = profile.CityId;
            user.PostCode = profile.PostCode;
            user.Address = profile.Address;
            user.Name = profile.Name;
            user.CityId = 1;
            UpdateUser(user);
        }

        public void ChangeUserPassword(string userName, string newPassword)
        {
            var user = GetUserByUserName(userName);
            user.Password = PasswordHelper.EncodePasswordMd5(newPassword);
            UpdateUser(user);
        }

        public void EditStore(string username, InformationStoreViewModel profile)
        {
            var user = GetUserByUserName(username);
            var store = getStoreByUserId(user.UserId);

            if (profile.BannerFile != null)
            {
                string imagePath = "";
                if (profile.Banner != "store-banner.jpg")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Store/Banner", profile.Banner);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                profile.Banner = NameGenerator.GenerateUniqeCode() + Path.GetExtension(profile.BannerFile.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Store/Banner", profile.Banner);
                store.Banner = profile.Banner;
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    profile.BannerFile.CopyTo(stream);
                }
            }

            if (profile.LogoFile != null)
            {
                string imagePath = "";
                if (profile.Logo != "store10.png")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Store/Logo", profile.Logo);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                profile.Logo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(profile.LogoFile.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Store/Logo", profile.Logo);
                store.Logo = profile.Logo;
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    profile.LogoFile.CopyTo(stream);
                }
            }

            store.Name = profile.Name;
            store.User.Mail = profile.Email;
            store.GroupId = profile.GroupId;
            store.SubGroup = profile.SubGroup;
            store.Shoar = profile.Shoar;
            store.User.Mail = profile.Email;
            store.User.Tel = profile.Tel;
            store.User.WebSite = profile.WebSite;
            store.User.Address = profile.Address;
            store.Description = profile.Description;
            store.Instagram = profile.Instagram;
            store.Telegram = profile.Telegram;
            store.User.WhatsApp = profile.WhatsApp;
            UpdateStore(store);
        }

        public void EditUserFromAdmin(UsersViewModel.EditUserViewModel editUser)
        {
            User user = getUserById(editUser.UserId);
            user.Email = editUser.Email;
            user.UserId = editUser.UserId;
            user.Password = editUser.ActiveCode;
            user.ActiveCode = editUser.ActiveCode;
            if (editUser.UserAvatar != null)
            {
                //Delete Old Image
                if (editUser.AvatarName != "Default.jpg")
                {
                    string deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", editUser.AvatarName);
                    if (File.Exists(deletePath))
                    {
                        File.Delete(deletePath);
                    }
                }

                //Save New Image

                user.UserAvatar = NameGenerator.GenerateUniqeCode() + Path.GetExtension(editUser.UserAvatar.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.UserAvatar);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    editUser.UserAvatar.CopyTo(stream);
                }
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public List<SelectListItem> GetAds()
        {
            return _context.TypeAds.Select(l => new SelectListItem()
            {
                Value = l.typeAdId.ToString(),
                Text = l.TypeAdTitle
            }).ToList();
        }

        public List<SelectListItem> GetCities()
        {
            return _context.Cities.Select(l => new SelectListItem()
            {
                Value = l.CityId.ToString(),
                Text = l.Name
            }).ToList();
        }

        public UsersForAdminViewModel GetDeleteUsers(int pageId = 1, string filterEmail = "", string filterUserName = "")
        {
            IQueryable<User> result = _context.Users.IgnoreQueryFilters().Where(u => u.IsDelete);

            if (!string.IsNullOrEmpty(filterEmail))
            {
                result = result.Where(u => u.Email.Contains(filterEmail));
            }

            if (!string.IsNullOrEmpty(filterUserName))
            {
                result = result.Where(u => u.UserName.Contains(filterUserName));
            }

            int take = 20;
            int skip = (pageId - 1) * take;

            UsersForAdminViewModel list = new UsersForAdminViewModel();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            list.Users = result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();
            return list;
        }

        public City getCityById(int cityId)
        {
            return _context.Cities.Find(cityId);
        }

        public Store getStoreByUserId(int userId)
        {
            return _context.Stores.SingleOrDefault(c=>c.UserId==userId);
        }
        public Store getStoreByStoreId(int storeId)
        {
            return _context.Stores.SingleOrDefault(c => c.StoreId == storeId);
        }

        public List<SelectListItem> getWithdrawalTypes()
        {
            return _context.WithdrawalTypes.Select(l => new SelectListItem()
            {
                Value = l.WithdrawalTypeId.ToString(),
                Text = l.Title
            }).ToList();
        }

        public List<SelectListItem> getCurrency()
        {
            return _context.Currencies.Select(l => new SelectListItem()
            {
                Value = l.CurrencyId.ToString(),
                Text = l.Name
            }).ToList();
        }


        public List<SelectListItem> getToCurrency()
        {
            return _context.ToCurrencies.Select(l => new SelectListItem()
            {
                Value = l.ToCurrencyId.ToString(),
                Text = l.Title
            }).ToList();
        }

        public void AddWithdrawal(Withdrawal withdrawal)
        {
            Withdrawal w = new Withdrawal();

            w.WithdrawalTypeId = withdrawal.WithdrawalTypeId;
            w.Amount = withdrawal.Amount;
            w.UserId = withdrawal.UserId;
            w.Address = withdrawal.Address;

            _context.Add(withdrawal);
            _context.SaveChanges();
        }

        public void AddExchange(Exchange exchange)
        {
            Exchange w = new Exchange();

            w.ToCurrencyId = exchange.ToCurrencyId;
            w.Amount = exchange.Amount;
            w.UserId = exchange.UserId;

            _context.Add(exchange);
            _context.SaveChanges();
        }

        public InformationStoreViewModel GetStoreInformation(string username)
        {
            var user = GetUserByUserName(username);
            var store= getStoreByUserId(user.UserId);
            InformationStoreViewModel information = new InformationStoreViewModel();
            information.UserId = user.UserId;
            information.Name = store.Name;
            information.Banner = store.Banner;
            information.Logo = store.Logo;
            information.Shoar = store.Shoar;
            information.Description = store.Description;
            information.Instagram = store.Instagram;
            information.Telegram = store.Telegram;
            information.Email = user.Mail;
            information.Tel = user.Tel;
            information.WebSite = user.WebSite;
            information.WhatsApp = user.WhatsApp;
            information.Address = user.Address;

            return information;
        }

        public User getUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public User GetUserByUserName(string username)
        {
            return _context.Users.Include(c=>c.City).SingleOrDefault(u => u.UserName == username);
        }

        public UsersViewModel.EditUserViewModel GetUserForShowInEditMode(int userId)
        {
            return _context.Users.Where(u => u.UserId == userId)
                .Select(u => new UsersViewModel.EditUserViewModel()
                {
                    UserId = u.UserId,
                    AvatarName = u.UserAvatar,
                    Email = u.Email,
                    UserName = u.UserName,
                    UserRoles = u.UserRoles.Select(r => r.RoleId).ToList()
                }).Single();
        }

        public int GetUserIdByUserName(string userName)
        {
            return _context.Users.Single(u => u.UserName == userName).UserId;
        }

        public InformationUserViewModel GetUserInformation(string username)
        {
            var user = GetUserByUserName(username);
            InformationUserViewModel information = new InformationUserViewModel();
            information.UserName = username;
            information.Email = user.Email;
            information.RegisterDate = user.RegisterDate;
            information.Wallet = BalanceUserWallet(username);
            information.btc = Balancebtc(username);
            information.doge = Balancedoge(username);
            information.eth = Balanceeth(username);
            information.Name = user.Name;
            information.Family = user.Family;
            information.Mail = user.Mail;
            information.Tel = user.Tel;
            information.WhatsApp = user.WhatsApp;
            information.WebSite = user.WebSite;
            information.City = user.City.Name;
            information.PostCode = user.PostCode;
            information.Address = user.Address;
            information.CityId = user.City.CityId;

            return information;
        }

        public InformationUserViewModel GetUserInformation(int userId)
        {
            var user = getUserById(userId);
            InformationUserViewModel information = new InformationUserViewModel();
            information.UserName = user.UserName;
            information.Email = user.Email;
            information.RegisterDate = user.RegisterDate;
            information.Wallet = BalanceUserWallet(user.UserName);

            return information;
        }

        public UsersForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUserName = "")
        {
            IQueryable<User> result = _context.Users;

            if (!string.IsNullOrEmpty(filterEmail))
            {
                result = result.Where(u => u.Email.Contains(filterEmail));
            }

            if (!string.IsNullOrEmpty(filterUserName))
            {
                result = result.Where(u => u.UserName.Contains(filterUserName));
            }

            int take = 20;
            int skip = (pageId - 1) * take;

            UsersForAdminViewModel list = new UsersForAdminViewModel();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            list.Users = result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();
            return list;
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public Tuple<List<ShowStoreListItemViewModel>, int> GetArticle(int pageId = 1, int take = 0, int cid = 0)
        {
            var result = _context.Stores;

            if (take == 0)
                take = 8;



            int skip = (pageId - 1) * take;

            int pageCount = result.Select(c => new ShowStoreListItemViewModel()
            {
                ImageName = c.Logo,
                StoreName = c.Name,
                StoreId = c.StoreId
            }).Count() / take;

            var query = result.Select(c => new ShowStoreListItemViewModel()
            {
                ImageName = c.Logo,
                StoreName = c.Name,
                StoreId = c.StoreId
            }).Skip(skip).Take(take).ToList();

            if (cid > 0)
            {

                return Tuple.Create(query.OrderByDescending(c => c.StoreId).Where(c => c.StoreId == cid).ToList(), pageCount);
            }

            return Tuple.Create(query.OrderByDescending(c => c.StoreId).ToList(), pageCount);
        }

        public User LoginUser(LoginViewModel login)
        {
            string hashPasword = PasswordHelper.EncodePasswordMd5(login.Password);
            string email = FixedText.FixEmail(login.Email);
            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == hashPasword);
        }

        public void UpdateStore(Store store)
        {
            _context.Update(store);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public User GetUserByActiveCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(u=>u.ActiveCode==activeCode);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShahrKoodak.Core.DTOs;
using ShahrKoodak.Core.DTOs.Store;
using ShahrKoodak.Core.DTOs.User;
using ShahrKoodak.DataLayer.Entities.User;
using ShahrKoodak.DataLayer.Entities.Wallet;

namespace ShahrKoodak.Core.Services.Interfaces
{
    public interface IUserService
    {
        Tuple<List<ShowStoreListItemViewModel>, int> GetArticle(int pageId = 1, int take = 0, int cid = 0);
        User LoginUser(LoginViewModel login);
        bool ActiveAcount(string activeCode);
        User GetUserByActiveCode(string activeCode);
        int AddUserFromAdmin(UsersViewModel.CreateUserViewModel user);
        int AddUser(User user);
        int AddStore(Store store);
        InformationUserViewModel GetUserInformation(string username);
        List<SelectListItem> getWithdrawalTypes();
        List<SelectListItem> getFromCurrency();
        List<SelectListItem> getToCurrency();
        void AddWithdrawal(Withdrawal withdrawal);
        void AddExchange(Exchange exchange);
        InformationStoreViewModel GetStoreInformation(string username);
        void EditProfile(string username, InformationUserViewModel profile);
        void EditStore(string username, InformationStoreViewModel profile);
        InformationUserViewModel GetUserInformation(int userId);
        User GetUserByUserName(string username);
        decimal BalanceUserWallet(string userName);
        decimal Balancebtc(string userName);
        decimal Balancedoge(string userName);
        decimal Balanceeth(string userName);
        int GetUserIdByUserName(string userName);
        User getUserById(int userId);
        City getCityById(int cityId);
        Store getStoreByUserId(int userId);
        Store getStoreByStoreId(int storeId);

        void DeleteUser(int userId);
        List<SelectListItem> GetAds();

        void UpdateUser(User user);
        void UpdateStore(Store store);
        UsersViewModel.EditUserViewModel GetUserForShowInEditMode(int userId);
        void EditUserFromAdmin(UsersViewModel.EditUserViewModel editUser);
        UsersForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUserName = "");
        UsersForAdminViewModel GetDeleteUsers(int pageId = 1, string filterEmail = "", string filterUserName = "");

        bool IsExistEmail(string email);
        bool IsExistUserName(string userName);
        List<SelectListItem> GetCities();
        void ChangeUserPassword(string userName, string newPassword);

    }
}

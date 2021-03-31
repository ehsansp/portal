using System;
using System.Collections.Generic;
using System.Text;
using ShahrKoodak.DataLayer.Entities.User;

namespace ShahrKoodak.Core.Services.Interfaces
{
    public interface IPermissionService
    {
        #region Roles

        List<Role> GetRole();
        void AddRolesToUser(List<int> rolesId, int userId);


        #endregion

        bool CheckPermission(int permissionId, string userName);
        void EditRolesUser(int userId, List<int> rolesId);


    }
}

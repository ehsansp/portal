using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Context;
using ShahrKoodak.DataLayer.Entities.User;

namespace ShahrKoodak.Core.Services
{
    public class PermissionService : IPermissionService
    {
        private ShahrContext _context;

        public PermissionService(ShahrContext context)
        {
            _context = context;
        }

        public void AddRolesToUser(List<int> rolesId, int userId)
        {
            foreach (int roleId in rolesId)
            {
                _context.UserRoles.Add(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });
            }

            _context.SaveChanges();
        }

        public bool CheckPermission(int permissionId, string userName)
        {
            int userId = _context.Users.Single(u => u.UserName == userName).UserId;

            List<int> UserRoles = _context.UserRoles
                .Where(r => r.UserId == userId).Select(r => r.RoleId).ToList();

            if (!UserRoles.Any())
                return false;

            List<int> RolesPermission = _context.RolePermissions
                .Where(p => p.PermissionId == permissionId).Select(p => p.RoleId).ToList();

            return RolesPermission.Any(p => UserRoles.Contains(p));
        }

        public void EditRolesUser(int userId, List<int> rolesId)
        {
            _context.UserRoles.Where(r => r.UserId == userId).ToList().ForEach(r => _context.UserRoles.Remove(r));

            //Add New Roles
            AddRolesToUser(rolesId, userId);
        }

        public List<Role> GetRole()
        {
            return _context.Roles.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ShahrKoodak.DataLayer.Entities.User;

namespace ShahrKoodak.DataLayer.Entities.Permission
{
    public class RolePermission
    {
        [Key]
        public int RP_Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public Role Role { get; set; }
        public Permissoin Permission { get; set; }
    }
}

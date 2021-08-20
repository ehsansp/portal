using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class Operator
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public string Salt { get; set; }
        public DateTime? LastPasswordChangedAt { get; set; }
        public DateTime? FirstLoginAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public DateTime? LastLoginAttemptAt { get; set; }
        public int LastLoginAttemptsCount { get; set; }
        public string LastIP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public OperatorRole Role { get; set; }
        public bool IsActive { get; set; }
    }
}

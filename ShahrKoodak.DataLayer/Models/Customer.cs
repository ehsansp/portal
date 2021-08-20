using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class Customer
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
        public string FatherName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string NationalCode { get; set; }
        public string Cellphone { get; set; }
        public string Phone { get; set; }
        public int? ProvinceId { get; set; }
        public Province Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string BourseExchangeCode { get; set; }
        public string Email { get; set; }
        public int? EducationLevelId { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public string EducationField { get; set; }
        public string JobTitle { get; set; }
        public bool IsActive { get; set; }
        public string ReferrerCode { get; set; }
        public string TrackingCode { get; set; }
        public string Description { get; set; }
    }
}

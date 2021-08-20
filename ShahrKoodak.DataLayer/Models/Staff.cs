using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string Education { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int OrganizationUnitId { get; set; }
        public OrganizationUnit OrganizationUnit { get; set; }
        public int StaffPositionId { get; set; }
        public StaffPosition StaffPosition { get; set; }
        public bool IsActive { get; set; }
        public int SortIndex { get; set; }
        public bool IsSecondLanguage { get; set; }
    }
}

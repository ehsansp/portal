using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BankId { get; set; }
        public Bank Bank { get; set; }
        public string BranchTitle { get; set; }
        public string AccountOwner { get; set; }
        public string AccountNumber { get; set; }
        public string ShebaNumber { get; set; }
        public int SortIndex { get; set; }
        public bool IsActive { get; set; }
        public string SendRequestsToEmails { get; set; }
        public bool IsSecondLanguage { get; set; }
    }
}

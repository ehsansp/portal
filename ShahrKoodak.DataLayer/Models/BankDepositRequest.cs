using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class BankDepositRequest
    {
        [Key]
        public int BankDepositId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BankAccountId { get; set; }

       
        public DateTime DepositedAt { get; set; }
        public string DepositorName { get; set; }
        public string NationalCode { get; set; }
        public string Cellphone { get; set; }
        public int Amount { get; set; }
        public int BankId { get; set; }
        public string BranchTitle { get; set; }
        public string ReceiptCode { get; set; }
        public string Description { get; set; }
        public string TrackingCode { get; set; }
        public bool? IsValid { get; set; }
        public int? ValidatedBy { get; set; }
        public DateTime? ValidatedAt { get; set; }
        public string ValidationNote { get; set; }
        
        [ForeignKey("BankId")]
        public Bank Bank { get; set; }
    }
}

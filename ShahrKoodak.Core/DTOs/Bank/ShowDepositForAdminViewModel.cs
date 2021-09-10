using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Bank
{
    public class ShowDepositForAdminViewModel
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string NationalCode { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public int Amount { get; set; }
        public string BranchTitle { get; set; }
    }
}

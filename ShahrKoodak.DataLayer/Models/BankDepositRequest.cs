﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class BankDepositRequest
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
        public DateTime DepositedAt { get; set; }
        public string DepositorName { get; set; }
        public string NationalCode { get; set; }
        public string Cellphone { get; set; }
        public int Amount { get; set; }
        public int BankId { get; set; }
        public Bank Bank { get; set; }
        public string BranchTitle { get; set; }
        public string ReceiptCode { get; set; }
        public string Description { get; set; }
        public string TrackingCode { get; set; }
        public bool? IsValid { get; set; }
        public int? ValidatedBy { get; set; }
        public DateTime? ValidatedAt { get; set; }
        public string ValidationNote { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.User
{
    public class Withdrawal
    {
        [Key]
        public int WithdrawalId { get; set; }

        public int UserId { get; set; }
        public int WithdrawalTypeId { get; set; }
        public int CurrencyId  { get; set; }
        public string Amount { get; set; }
        public string Address { get; set; }
        public WithdrawalType WithdrawalType { get; set; }
        public Currency Currency { get; set; }
    }
}

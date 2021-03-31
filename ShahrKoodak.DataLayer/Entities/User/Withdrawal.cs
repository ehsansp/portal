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
        public string Amount { get; set; }
        public WithdrawalType WithdrawalType { get; set; }
    }
}

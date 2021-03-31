using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.User
{
    public class WithdrawalType
    {
        [Key]
        public int WithdrawalTypeId { get; set; }

        public string Title { get; set; }
        public int UserId { get; set; }

        public List<Withdrawal> Withdrawals { get; set; }
    }
}

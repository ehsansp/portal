using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.User
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }
        public string Name { get; set; }

        public List<Withdrawal> Withdrawals { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Wallet
{
    public class Exchange
    {
        [Key]
        public int ExchangeId { get; set; }
        public string Amount { get; set; }
        public int ToCurrencyId { get; set; }
        public int FromCurrencyId { get; set; }
        public int UserId { get; set; }

        public FromCurrency FromCurrency { get; set; }
        public ToCurrency ToCurrency { get; set; }
    }
}

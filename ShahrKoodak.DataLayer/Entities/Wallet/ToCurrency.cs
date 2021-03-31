using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Wallet
{
    public class ToCurrency
    {
        [Key]
        public int ToCurrencyId { get; set; }

        public string Title { get; set; }
        public List<Exchange> Exchanges { get; set; }
    }
}

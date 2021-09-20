using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class Bank
    {
        [Key]
        public int BankId { get; set; }
        public string Title { get; set; }
        public string EnTitle { get; set; }
        public string Logo { get; set; }


        public List<BankDepositRequest> BankDepositRequest { get; set; }
        public List<BankAccount> BankAccounts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Customer
{
    public class ShowCustomerForWebSiteViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
    }
}

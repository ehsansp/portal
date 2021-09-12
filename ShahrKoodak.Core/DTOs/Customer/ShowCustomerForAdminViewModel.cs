using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Customer
{
    public class ShowCustomerForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LastIP { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
}

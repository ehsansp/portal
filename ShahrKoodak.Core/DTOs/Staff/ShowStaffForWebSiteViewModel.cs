using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Staff
{
    public class ShowStaffForWebSiteViewModel
    {
        public int Id { get; set; }
        public string Education { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string StaffPosition { get; set; }
        public string OrganizationUnit { get; set; }
        public string Phone { get; set; }
    }
}

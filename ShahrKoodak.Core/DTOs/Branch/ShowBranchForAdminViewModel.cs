using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Branch
{
    public class ShowBranchForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string ManagerName { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }
}

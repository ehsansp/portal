using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Staff
{
   public  class ShowStaffForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public bool IsActive { get; set; }
        public int SortIndex { get; set; }
    }
}

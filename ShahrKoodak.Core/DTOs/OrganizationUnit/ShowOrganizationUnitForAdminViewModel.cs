using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.OrganizationUnit
{
    public class ShowOrganizationUnitForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public int SortIndex { get; set; }
    }
}

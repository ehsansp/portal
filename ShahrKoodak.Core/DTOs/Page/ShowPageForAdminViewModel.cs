using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Page
{
    public class ShowPageForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public int ViewCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Brand
{
    public class ShowBrandForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.FAQ
{
    public class ShowFAQForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Photo { get; set; }
        public bool IsActive { get; set; }
        public int SortIndex { get; set; }
    }
}

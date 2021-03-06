using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Product
{
    public class ShowProductForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string RouteTitle { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public bool IsActive { get; set; }
        public int SortIndex { get; set; }
    }
}

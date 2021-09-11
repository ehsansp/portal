using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Province
{
    public class ShowProvinceForAdminViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EnTitle { get; set; }
        public int SortIndex { get; set; }
    }
}

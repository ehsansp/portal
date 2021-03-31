using System;
using System.Collections.Generic;
using System.Text;

namespace ShahrKoodak.Core.DTOs.Product
{
    public class ShowProductForAdminViewModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public int EpisodeCount { get; set; }
        public string ProductGroup { get; set; }
        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ShahrKoodak.Core.DTOs.Feature
{
    public class ShowProductFeatureForAdminViewModel
    {
        public int PFID { get; set; }
        public int ProductId { get; set; }
        public string Value { get; set; }
        public int FeatureId { get; set; }
        public string Title { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ShahrKoodak.Core.DTOs.Product
{
    public class ShowFeatureViewModel
    {
        public int ProductId { get; set; }
        public int FeatureId { get; set; }
        public int PRId { get; set; }
        public string Value { get; set; }
        public string Feature { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ShahrKoodak.Core.DTOs.Product
{
    public class ShowProductListItemViewModel
    {
        public int ProductId { get; set; }
        public string GroupTitle { get; set; }
        public string Title { get; set; }
        public string Title2 { get; set; }
        public string Tel { get; set; }
        public int Mantaghe { get; set; }
        public string Address { get; set; }
        public string ShortDescription { get; set; }
        public string ImageName { get; set; }
        public int StarNumber { get; set; }
        public int CG { get; set; }
        public int Price { get; set; }
        public bool PriceType { get; set; }
        public DateTime CreateDate { get; set; }
        public int Counter { get; set; }
        public string Region { get; set; }
    }
}

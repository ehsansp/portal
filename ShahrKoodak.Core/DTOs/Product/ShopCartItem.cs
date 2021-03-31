using System;
using System.Collections.Generic;
using System.Text;

namespace ShahrKoodak.Core.DTOs.Product
{
    public class ShopCartItem
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
    }

    public class ShopCartViewModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int Sum { get; set; }
        public string ImageName { get; set; }
    }
}

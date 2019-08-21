using System;
using System.Collections.Generic;

namespace ShopBasketWeb.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductInfo = new HashSet<ProductInfo>();
        }

        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CatId { get; set; }

        public Category Cat { get; set; }
        public ICollection<ProductInfo> ProductInfo { get; set; }
    }
}

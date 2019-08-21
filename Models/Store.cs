using System;
using System.Collections.Generic;

namespace ShopBasketWeb.Models
{
    public partial class Store
    {
        public Store()
        {
            ProductInfo = new HashSet<ProductInfo>();
        }

        public int StroreId { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public ICollection<ProductInfo> ProductInfo { get; set; }
    }
}

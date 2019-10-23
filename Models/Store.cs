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

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string StoreImageUrl { get; set; }

        public ICollection<ProductInfo> ProductInfo { get; set; }
    }
}

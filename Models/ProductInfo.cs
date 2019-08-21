using System;
using System.Collections.Generic;

namespace ShopBasketWeb.Models
{
    public partial class ProductInfo
    {
        public ProductInfo()
        {
            ListProductInfo = new HashSet<ListProductInfo>();
        }

        public int StoreId { get; set; }
        public string Barcode { get; set; }
        public int ProductInfo1 { get; set; }
        public int PriceId { get; set; }
        public bool? OnSpecial { get; set; }

        public Product BarcodeNavigation { get; set; }
        public PriceInfo Price { get; set; }
        public Store Store { get; set; }
        public ICollection<ListProductInfo> ListProductInfo { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ShopBasketWeb.Models
{
    public partial class ListProductInfo
    {
        public int ListId { get; set; }
        public int ProductInfo { get; set; }
        public int? Qty { get; set; }

        public ShoppingList List { get; set; }
        public ProductInfo ProductInfoNavigation { get; set; }
    }
}

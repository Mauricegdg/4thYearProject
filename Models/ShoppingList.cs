using System;
using System.Collections.Generic;

namespace ShopBasketWeb.Models
{
    public partial class ShoppingList
    {
        public string UserName { get; set; }
        public string Barcode { get; set; }
        public int? Qty { get; set; }

        public Product BarcodeNavigation { get; set; }
        public User UserNameNavigation { get; set; }
    }
}

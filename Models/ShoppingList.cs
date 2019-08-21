using System;
using System.Collections.Generic;

namespace ShopBasketWeb.Models
{
    public partial class ShoppingList
    {
        public ShoppingList()
        {
            ListProductInfo = new HashSet<ListProductInfo>();
        }

        public int ListId { get; set; }
        public string UserName { get; set; }
        public decimal? TotalCost { get; set; }
        public string ItemList { get; set; }

        public User UserNameNavigation { get; set; }
        public ICollection<ListProductInfo> ListProductInfo { get; set; }
    }
}

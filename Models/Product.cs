using System;
using System.Collections.Generic;

namespace ShopBasketWeb.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductInfo = new HashSet<ProductInfo>();
            ShoppingList = new HashSet<ShoppingList>();
        }

        public string Barcode { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public int CatId { get; set; }
        public byte[] ProdImg { get; set; }

        public Category Cat { get; set; }
        public ICollection<ProductInfo> ProductInfo { get; set; }
        public ICollection<ShoppingList> ShoppingList { get; set; }
    }
}

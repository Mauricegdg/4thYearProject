using System;
using System.Collections.Generic;

namespace ShopBasketWeb.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int CatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}

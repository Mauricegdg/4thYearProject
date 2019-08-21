using System;
using System.Collections.Generic;

namespace ShopBasketWeb.Models
{
    public partial class User
    {
        public User()
        {
            ShoppingList = new HashSet<ShoppingList>();
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Longitude { get; set; }
        public bool? AdminStatus { get; set; }
        public string Latitude { get; set; }
        public string UserName { get; set; }
        public string Surename { get; set; }
        public string Salt { get; set; }

        public ICollection<ShoppingList> ShoppingList { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ShopBasketWeb.Models
{
    public partial class UserType
    {
        public UserType()
        {
            User = new HashSet<User>();
        }

        public int TypeId { get; set; }
        public string UserTitle { get; set; }

        public ICollection<User> User { get; set; }
    }
}

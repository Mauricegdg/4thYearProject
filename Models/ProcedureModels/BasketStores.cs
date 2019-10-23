using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBasketWeb.Models.ProcedureModels
{
    public class BasketStores
    {
        public float Total_Price { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Store_Name { get; set; }

        public string StoreImageUrl { get; set; }

        public int StoreID { get; set; }
    }
}

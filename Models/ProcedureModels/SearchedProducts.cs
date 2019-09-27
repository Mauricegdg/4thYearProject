using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBasketWeb.Models.ProcedureModels
{
    public class SearchedProducts
    {
        public string Barcode { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }

        public string CatName { get; set; }

        public float Current_Price { get; set; }

        public byte[] ProdImg { get; set; }

        public string Latitude { get; set; }

        public string longitude { get; set; }

        public string Store_Name { get; set; }

        public string StoreImageUrl { get; set; }

        public int StoreID { get; set; }
    }
}

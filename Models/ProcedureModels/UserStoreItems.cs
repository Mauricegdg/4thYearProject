using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBasketWeb.Models.ProcedureModels
{
    public class UserStoreItems
    {
        public string Barcode { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }

        public byte[] ProdImg { get; set; }

        public int Qty { get; set; }

        public bool OnSpecial { get; set; }

        public float Current_Price { get; set; }
    }
}

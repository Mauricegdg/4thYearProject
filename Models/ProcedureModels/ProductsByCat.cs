using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBasketWeb.Models.ProcedureModels
{
    public class ProductsByCat
    {
        public string Barcode { get; set; }
        public string ProdName { get; set; }

        public int StoreID { get; set; }

        public string ProdDescription { get; set; }

        public byte[] ProdImg { get; set; }
    }
}

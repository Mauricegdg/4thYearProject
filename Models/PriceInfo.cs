using System;
using System.Collections.Generic;

namespace ShopBasketWeb.Models
{
    public partial class PriceInfo
    {
        public PriceInfo()
        {
            ProductInfo = new HashSet<ProductInfo>();
        }

        public int PriceId { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? PreviousPrice { get; set; }
        public DateTime? CurrentPriceDate { get; set; }
        public DateTime? PreviousPrceDate { get; set; }

        public ICollection<ProductInfo> ProductInfo { get; set; }
    }
}

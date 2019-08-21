using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopBasketWeb.Models;
using ShopBasketWeb.Models.ProcedureModels;

namespace ShopBasketWeb.DataAccess
{

    public interface IDataProvider
    {
        Task<IEnumerable<ProductsOnSpecial>> GetProductsOnSpecial();

        Task<IEnumerable<SearchedProducts>> GetSeachedProducts(string searchData);
    }
}

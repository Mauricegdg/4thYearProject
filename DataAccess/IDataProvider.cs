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
        Task<IEnumerable<ProductsOnSpecial>> GetProductsOnSpecial(int StoreID);

        Task<IEnumerable<SearchedProducts>> GetSeachedProducts(string searchData);

        Task<IEnumerable<ProductsByCat>> GetProductsByCategory(int CatID);
        Task<IEnumerable<Store_In_Range>> GetStoreLocations();

        Task AddToBasket(ShoppingListInfo shoppingListInfo);
        Task<IEnumerable<ProductsOnSpecial>> GetBasketProducts(string UserName);
        Task DeleteAllFromBasket(string UserName);
        Task DeleteFromBasket(string Barcode, string UserName);
        Task UpdateQty(ShoppingListInfo shoppingListInfo, int Qty);
    }
}

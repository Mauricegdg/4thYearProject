using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using ShopBasketWeb.Models;
using ShopBasketWeb.Models.ProcedureModels;

namespace ShopBasketWeb.DataAccess
{
    public class DataProvider : IDataProvider
    {
        private readonly string connectionString = "Server=tcp:marketserverbtech.database.windows.net;Database=GroceryDB;User ID=Maurice;Password=Whicod22;";

        private SqlConnection sqlConn;

        public async Task<IEnumerable<ProductsOnSpecial>> GetProductsOnSpecial(int StoreID)
        {
            // IEnumerable<ProductsOnSpecial> productsOnSpecials;

            using (var sqlConn = new SqlConnection(connectionString))
            {
                await sqlConn.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@StoreID", StoreID);

                return await sqlConn.QueryAsync<ProductsOnSpecial>("dbo.uspGetProductsOnSpecial",dynamicParameters, commandType: CommandType.StoredProcedure);
            }

           
        }

        public async Task<IEnumerable<Store_In_Range>> GetStoreLocations()
        {
            IEnumerable<Store_In_Range> storeLocations;

            using (var sqlConn = new SqlConnection(connectionString))
            {
                await sqlConn.OpenAsync();

                storeLocations = await sqlConn.QueryAsync<Store_In_Range>("uspGetAllStoreLocations", null, commandType: CommandType.StoredProcedure);
            }

            return storeLocations;
        }

        public async Task<IEnumerable<SearchedProducts>> GetSeachedProducts(string searchData)
        {
            

            using (var sqlConn = new SqlConnection(connectionString))
            {
                await sqlConn.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@searchData", searchData);

                return await sqlConn.QueryAsync<SearchedProducts>("dbo.uspGetSearchProducts",dynamicParameters, commandType: CommandType.StoredProcedure);
            }

            
        }

        public async Task<IEnumerable<ProductsByCat>> GetProductsByCategory(int CatID)
        {


            using (var sqlConn = new SqlConnection(connectionString))
            {
                await sqlConn.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CatID", CatID);

                return await sqlConn.QueryAsync<ProductsByCat>("dbo.uspGetProductsByCategory", dynamicParameters, commandType: CommandType.StoredProcedure);
            }


        }

        public async Task<IEnumerable<UserStoreItems>> GetUserStoreItems(string userName,int StoreID)
        {


            using (var sqlConn = new SqlConnection(connectionString))
            {
                await sqlConn.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@userName", userName);
                dynamicParameters.Add("@storeID", StoreID);

                return await sqlConn.QueryAsync<UserStoreItems>("dbo.uspGetBasketStoreItems", dynamicParameters, commandType: CommandType.StoredProcedure);
            }


        }

        public async Task AddToBasket(ShoppingListInfo shoppingListInfo)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                await sqlConn.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@barcode", shoppingListInfo.Barcode);
                dynamicParameters.Add("@userName", shoppingListInfo.UserName);
                dynamicParameters.Add("@qty", shoppingListInfo.Qty);

                await sqlConn.ExecuteAsync("dbo.uspInsertToBasket", dynamicParameters, commandType: CommandType.StoredProcedure);


            }

        }

        public async Task UpdateQty(ShoppingListInfo shoppingListInfo)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                await sqlConn.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@barcode", shoppingListInfo.Barcode);
                dynamicParameters.Add("@userName", shoppingListInfo.UserName);
                dynamicParameters.Add("@qty", shoppingListInfo.Qty);

                await sqlConn.ExecuteAsync("dbo.uspUpdateQty", dynamicParameters, commandType: CommandType.StoredProcedure);


            }

        }

        //public async Task DeleteFromBasket(string Barcode, string UserName)
        //{
        //    using (var sqlConn = new SqlConnection(connectionString))
        //    {
        //        await sqlConn.OpenAsync();
        //        var dynamicParameters = new DynamicParameters();
        //        dynamicParameters.Add("@barcode", Barcode);
        //        dynamicParameters.Add("@userName", UserName);

        //        await sqlConn.ExecuteAsync("dbo.uspDeleteFromBasket", dynamicParameters, commandType: CommandType.StoredProcedure);


        //    }

        //}

        public async Task DeleteAllFromBasket(string UserName)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                await sqlConn.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@userName", UserName);

                await sqlConn.ExecuteAsync("dbo.uspDeleteAllFromBasket", dynamicParameters, commandType: CommandType.StoredProcedure);


            }

        }

        public async Task<IEnumerable<UserItems>> GetBasketProducts(string UserName)
        {


            using (var sqlConn = new SqlConnection(connectionString))
            {
                await sqlConn.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@userName", UserName);

                return await sqlConn.QueryAsync<UserItems>("dbo.uspGetBasketProducts", dynamicParameters, commandType: CommandType.StoredProcedure);
            }


        }

       public async Task<IEnumerable<BasketStores>> GetTotalPrices(string UserName)
        {


            using (var sqlConn = new SqlConnection(connectionString))
            {
                await sqlConn.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@userName", UserName);
                

                return await sqlConn.QueryAsync<BasketStores>("dbo.GetTotaItems", dynamicParameters, commandType: CommandType.StoredProcedure);
            }


        }

        public async Task<int> GetTotalItems(string UserName)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                await sqlConn.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@userName", UserName);


                return await sqlConn.QuerySingleOrDefaultAsync<int>("dbo.GetItemsInTotal", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

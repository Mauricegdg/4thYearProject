using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ShopBasketWeb.Models;
using ShopBasketWeb.Models.ProcedureModels;

namespace ShopBasketWeb.DataAccess
{
    public class DataProvider : IDataProvider
    {
        private readonly string connectionString = "Server=tcp:marketserverbtech.database.windows.net;Database=GroceryDB;User ID=Maurice;Password=Whicod22;";

        private SqlConnection sqlConn;

        public async Task<IEnumerable<ProductsOnSpecial>> GetProductsOnSpecial()
        {
            IEnumerable<ProductsOnSpecial> productsOnSpecials;

            using (var sqlConn = new SqlConnection(connectionString))
            {
                await sqlConn.OpenAsync();

                productsOnSpecials = await sqlConn.QueryAsync<ProductsOnSpecial>("dbo.uspGetProductsOnSpecial", null, commandType: CommandType.StoredProcedure);
            }

            return productsOnSpecials;
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
    }
}

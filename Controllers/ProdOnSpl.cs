using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBasketWeb.DataAccess;
using ShopBasketWeb.Models;
using ShopBasketWeb.Models.ProcedureModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBasketWeb.Controllers
{
    [Route("api/[controller]")]
    public class ProdOnSpl : Controller
    {
        private IDataProvider dataProvider;

        //private readonly string connectionString = "Server=tcp:marketserverbtech.database.windows.net;Database=GroceryDB;User ID=Maurice;Password=Whicod22;";

        public ProdOnSpl(IDataProvider dataprovider)
        {
            this.dataProvider = dataprovider;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductsOnSpecial>> GetProductsOnSpecial()
        {
             return await this.dataProvider.GetProductsOnSpecial();

        }
    }
}

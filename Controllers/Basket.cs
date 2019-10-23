using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using ShopBasketWeb.DataAccess;
using ShopBasketWeb.Models.ProcedureModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBasketWeb.Controllers
{
    [Route("api/[controller]")]
    public class Basket : Controller
    {
        private IDataProvider dataProvider;

        public Basket(IDataProvider dataprovider)
        {
            this.dataProvider = dataprovider;
        }

        [HttpGet("{UserName}")]
        public async Task<IEnumerable<BasketStores>> GetTotalPrices(string UserName)
        {
            return await this.dataProvider.GetTotalPrices(UserName);

        }
        
    }
}

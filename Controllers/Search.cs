using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopBasketWeb.DataAccess;
using ShopBasketWeb.Models.ProcedureModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBasketWeb.Controllers
{
    [Route("api/[controller]")]
    public class Search : Controller
    {
        private IDataProvider dataProvider;

       // private readonly string connectionString = "Server=tcp:marketserverbtech.database.windows.net;Database=GroceryDB;User ID=Maurice;Password=Whicod22;";

        public Search(IDataProvider dataprovider)
        {
            this.dataProvider = dataprovider;
        }

        [HttpGet("{searchdata}")]
        public async Task<IEnumerable<SearchedProducts>> GetSeachedProducts(string searchdata)
        {
            return await this.dataProvider.GetSeachedProducts(searchdata);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopBasketWeb.DataAccess;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBasketWeb.Controllers
{
    [Route("api/[controller]")]
    public class BasketItems : Controller
    {
        private IDataProvider dataProvider;

        public BasketItems(IDataProvider dataprovider)
        {
            this.dataProvider = dataprovider;
        }

        [HttpGet("{userName}")]
        public async Task<int> GetTotalItems(string UserName)
        {
            return await this.dataProvider.GetTotalItems(UserName);

        }

    }
}

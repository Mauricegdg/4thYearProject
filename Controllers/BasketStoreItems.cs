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
    public class BasketStoreItems : Controller
    {
        
        private IDataProvider dataProvider;

        public BasketStoreItems(IDataProvider dataprovider)
        {
            this.dataProvider = dataprovider;
        }


        [HttpGet("{userName}/{storeID}")]
        public async Task<IEnumerable<UserStoreItems>> GetUserStoreItems(string UserName,int storeID )
        {
            return await this.dataProvider.GetUserStoreItems(UserName,storeID);

        }
    }
}

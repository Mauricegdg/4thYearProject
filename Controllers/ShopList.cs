using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopBasketWeb.DataAccess;
using ShopBasketWeb.Models.ProcedureModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBasketWeb.Controllers
{
    [Route("api/[controller]")]
    public class ShopList : Controller
    {
        private IDataProvider dataProvider;

        public ShopList(IDataProvider dataprovider)
        {
            this.dataProvider = dataprovider;
        }

        // GET: api/<controller>
        [HttpGet("{userName}")]
        public async Task<IEnumerable<UserItems>> GetBasketProducts(string UserName)
        {
            return await this.dataProvider.GetBasketProducts(UserName);

        }


        // POST api/<controller>
        [HttpPost]
        public async Task Post([FromBody]ShoppingListInfo shoppingListInfo)
        {
            await this.dataProvider.AddToBasket(shoppingListInfo);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task Put([FromBody]ShoppingListInfo shoppingListInfo)
        {
            await this.dataProvider.UpdateQty(shoppingListInfo);
        }

        // DELETE api/<controller>/5
        //[HttpDelete("{barcode,userName}")]
        //public async Task Delete(string Barcode, string UserName)
       // {
        //    await this.dataProvider.DeleteFromBasket(Barcode, UserName);
        //}

        [HttpDelete("{userName}")]
        public async Task Delete(string UserName)
        {
            await this.dataProvider.DeleteAllFromBasket(UserName);
        }
    }
}

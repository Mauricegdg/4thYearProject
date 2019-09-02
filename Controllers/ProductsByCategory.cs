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
    public class ProductsByCategory : Controller
    {
        

        private IDataProvider dataProvider;


        public ProductsByCategory(IDataProvider dataprovider)
        {
            this.dataProvider = dataprovider;
        }

        [HttpGet("{CatID}")]
        public async Task<IEnumerable<ProductsByCat>> GetProductsByCategory(int CatID)
        {
            return await this.dataProvider.GetProductsByCategory(CatID);

        }
    }
}

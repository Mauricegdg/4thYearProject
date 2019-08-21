using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopBasketWeb.Models;
using ShopBasketWeb.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBasketWeb.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        GroceryDBContext dBContext = new GroceryDBContext();

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]User value)
        {
            //see if exists
            if (dBContext.User.Any(user => user.UserName.Equals(value.UserName)))
            {
                User user = dBContext.User.Where(u => u.UserName.Equals(value.UserName)).First();

                //Calculate hash Password from data of Client and compare with server with salt
                var client_post_hash_Password = Convert.ToBase64String(Common.SaltHashPassword(Encoding.ASCII.GetBytes(value.Password), Convert.FromBase64String(user.Salt)));

                if (client_post_hash_Password.Equals(user.Password))
                {
                    return JsonConvert.SerializeObject(user);
                }
                else return JsonConvert.SerializeObject("Wrong Password");
                
            }
            else
            {
                return JsonConvert.SerializeObject("User not existing in Database");
            }
        }

        
    }
}

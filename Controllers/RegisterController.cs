using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using ShopBasketWeb.Models;
using ShopBasketWeb.Utils;

namespace ShopBasketWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        GroceryDBContext dBContext = new GroceryDBContext();
        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
       // {
        //    return new string[] { "value1", "value2" };
       // }

        // GET api/values/5
       // [HttpGet("{id}")]
       // public ActionResult<string> Get(int id)
      //  {
        //    return "value";
       // }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] User value)
        {
            //See if User exists
            if (!dBContext.User.Any(user => user.UserName.Equals(value.UserName)))
            {   
                User user = new User();
                user.UserName = value.UserName;
                user.Salt = Convert.ToBase64String(Common.GetRandomSalt(16));
                user.Password = Convert.ToBase64String(Common.SaltHashPassword(Encoding.ASCII.GetBytes(value.Password), Convert.FromBase64String(user.Salt)));
                
                user.Name = value.Name;
                user.Surename = value.Surename;

                try
                {
                    dBContext.Add(user);
                    dBContext.SaveChanges();
                    return JsonConvert.SerializeObject("Register successfully");
                }
                catch (Exception ex)
                {

                    return JsonConvert.SerializeObject(ex.Message);
                }
            }
            else
            {
                return JsonConvert.SerializeObject("User is existing in Database");
            }
        }

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
       // {
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
       // {
       // }
    }
}

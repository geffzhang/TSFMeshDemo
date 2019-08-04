using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.Models;

namespace User.Controllers
{
    [Route("api/v6/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IHttpClientFactory _clientFactory;

        public UserController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET /api/v6/user/create
        [HttpGet("create")]
        public async  Task<ActionResult<AccountResult>> CreateAccount()
        {
            HttpClient httpClient = _clientFactory.CreateClient("shopclient");
            var response = await httpClient.GetAsync("/api/v6/shop/items");
            if (response.IsSuccessStatusCode)
            {
                return new AccountResult { Result = new Account() { UserId = "1234", UserName = "vincent" } };
            }
            else
            {
                throw new Exception("Error invoke /api/v6/shop/items");
            }
        }

        // GET /api/v6/user/account/query
        [HttpGet("account/query")]
        public async Task<ActionResult<UserAccount>> QueryAccount()
        {
            HttpClient httpClient = _clientFactory.CreateClient("shopclient");
            var response = await httpClient.GetAsync("/api/v6/shop/order");
            if (response.IsSuccessStatusCode)
            {
                return new UserAccount {  
                    UserId = "1234" , 
                    Detail = new Detail() { 
                     Deposit = 12000,
                     MoneyLeft = 52000
                } };
            }
            else
            {
                throw new Exception("Error invoke /api/v6/shop/orders");
            }
        }       
    }
}

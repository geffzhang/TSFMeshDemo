using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSF.Tracing.Propagation;
using User.Models;

namespace User.Controllers
{
    [Route("api/v6/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private HttpClient httpClient;

        public UserController(IHttpClientFactory clientFactory)
        {
            httpClient = clientFactory.CreateClient("shopclient");
        }

        // GET /api/v6/user/create
        [HttpGet("create")]
        public async  Task<ActionResult<AccountResult>> CreateAccount()
        {
            var response = await httpClient.GetAsync("/api/v6/shop/items");
            if (response.IsSuccessStatusCode)
            {
                return new AccountResult { Result = new Account() { UserId = "1234", UserName = "vincent" } };
            }
            else
            {
                throw new UnprocessableEntityException("Error invoke /api/v6/shop/items", 40000);
            }
        }

        // GET /api/v6/user/account/query
        [HttpGet("account/query")]
        public async Task<ActionResult<UserAccount>> QueryAccount()
        {
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
                throw new UnprocessableEntityException("Error invoke /api/v6/shop/orders", 40000);
            }
        }       
    }
}

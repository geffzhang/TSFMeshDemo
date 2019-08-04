using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("api/v6/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET api/v6/product/deliver
        [HttpGet("deliver")]
        public async Task<ActionResult<Deliver>> Deliver()
        {
            return new Deliver {  Destination = "shenzhen", ItemId = "002" };          
        }
    }
}
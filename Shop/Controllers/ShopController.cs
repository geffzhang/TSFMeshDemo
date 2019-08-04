using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using TSF.Tracing.Propagation;

namespace Shop.Controllers
{
    [Route("api/v6/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private HttpClient httpClient;

        public ShopController(IHttpClientFactory clientFactory)
        {
            httpClient = clientFactory.CreateClient("promotionclient"); 
        }

        // GET api/v6/shop/order
        [HttpGet("order")]
        public async Task<ActionResult<OrderItem>> Order()
        {
            var response = await httpClient.GetAsync("/api/v6/promotion/query");
            if (response.IsSuccessStatusCode)
            {
                return new OrderItem {  UserId = "1234", ItemId = "002" };
            }
            else
            {
                throw new UnprocessableEntityException("Error invoke /api/v6/promotion/query", 4000000);
            }
        }

        // GET api/v6/shop/items
        [HttpGet("items")]
        public ActionResult<ShopItemList> Items()
        {
            ShopItemList shopItems = new ShopItemList();
            shopItems.Items.Add(new Models.ShopItem() { ItemId = "001",  ItemName = "cloth" });
            shopItems.Items.Add(new Models.ShopItem() { ItemId = "002", ItemName = "cloth1" });
            shopItems.Items.Add(new Models.ShopItem() { ItemId = "003", ItemName = "cloth2" });

            return shopItems;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Promotion.Models;

namespace Promotion.Controllers
{
    [Route("api/v6/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private IHttpClientFactory _clientFactory;

        public PromotionController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET /api/v6/promotion/query
        [HttpGet("query")]
        public async Task<ActionResult<PromotionList>> Get()
        {
            PromotionList promotionList = new PromotionList();
            promotionList.Promotions.Add(new Models.Promotion() {  ItemId = "001", Status ="off"});
            promotionList.Promotions.Add(new Models.Promotion() { ItemId = "002", Status = "on" });
            promotionList.Promotions.Add(new Models.Promotion() { ItemId = "003", Status = "on" });

            return promotionList;
        }

        // GET /api/v6/promotion/item/discount
        [HttpGet("item/discount")]
        public async Task<ActionResult<ItemDiscount>> Discount()
        {
            HttpClient httpClient = _clientFactory.CreateClient("shopclient");
            var response = await httpClient.GetAsync("/api/v6/product/deliver");
            if (response.IsSuccessStatusCode)
            {
                return new ItemDiscount { Discount = "40", ItemId = "002" };
            }
            else
            {
                throw new Exception("Error invoke /api/v6/product/deliver");
            }
        }

    }
}

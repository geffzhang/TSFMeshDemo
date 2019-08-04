using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Promotion.Models;
using TSF.Tracing.Propagation;

namespace Promotion.Controllers
{
    [Route("api/v6/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private HttpClient httpClient;

        public PromotionController(IHttpClientFactory clientFactory)
        {
            httpClient = clientFactory.CreateClient("shopclient");
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
            var response = await httpClient.GetAsync("/api/v6/product/deliver");
            if (response.IsSuccessStatusCode)
            {
                return new ItemDiscount { Discount = "40", ItemId = "002" };
            }
            else
            {
                throw new UnprocessableEntityException("Error invoke /api/v6/product/deliver", 4000000);
            }
        }

    }
}

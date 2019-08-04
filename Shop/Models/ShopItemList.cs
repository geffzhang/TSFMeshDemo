using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ShopItemList
    {
        public  ShopItemList()
        {
            Items = new List<ShopItem>();
        }
        public List<ShopItem> Items { get; set; }
    }
}

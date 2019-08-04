using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promotion.Models
{
    public class PromotionList
    {
        public PromotionList()
        {
            Promotions = new List<Promotion>();
        }
        public List<Promotion> Promotions { get; set; }
    }
}

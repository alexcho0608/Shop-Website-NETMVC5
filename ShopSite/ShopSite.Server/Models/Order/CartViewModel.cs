using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSite.Server.Models.Order
{
    public class CartViewModel
    {
        public IEnumerable<OrderViewModel> Orders
        {
            get; set;
        }

        public int OrderId { get; set; }
    }
}
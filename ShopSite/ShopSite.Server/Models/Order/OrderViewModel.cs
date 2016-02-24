using ShopSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSite.Server.Models.Order
{
    public class OrderViewModel
    {
        public Item Item { get; set; }

        public int Total { get; set; }

    }
}
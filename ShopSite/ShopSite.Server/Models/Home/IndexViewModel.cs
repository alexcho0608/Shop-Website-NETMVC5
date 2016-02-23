using ShopSite.Server.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSite.Server.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<ItemResponseViewModel> items;

        public string Category { get; set; }
    }
}
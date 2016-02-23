using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSite.Server.Models.Items
{
    public class ItemSearchViewModel
    {
        public ICollection<ItemResponseViewModel> Items
        {
            get; set;
        }

        public int CurrentPage { get; set; }

        public decimal TotalPages { get; set; }

        public int PageSize { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopSite.Server.Models.Items
{
    public class SearchItemRequestModel
    {
        [DefaultValue("")]
        public string Search { get; set; }

        [DefaultValue("5")]
        public int PageSize{ get; set; }

        public string [] Category { get; set; }

        public string Sort { get; set; }
    }
}
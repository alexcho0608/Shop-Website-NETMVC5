

namespace ShopSite.Server.Models.Items
{
    using ForumSystem.Web.Infrastructure.Mapping;
    using ShopSite.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    public class ItemResponseViewModel : IMapFrom<Item>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double? Price { get; set; }

        public int Pieces { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Category Category { get; set; }

    }
}
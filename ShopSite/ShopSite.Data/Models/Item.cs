using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite.Data.Models
{
    public class Item
    {
        private ICollection<Rating> ratings;

        public Item()
        {
            ratings = new HashSet<Rating>();
        }
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double? Price { get; set; }

        public int Pieces { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Category Category {get;set;}

        public ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}

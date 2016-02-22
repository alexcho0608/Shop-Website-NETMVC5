using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopSite.Data.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        public int Rate { get; set; }

        public string UserId {get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public int ItemId { get; set;}

        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

    }
}

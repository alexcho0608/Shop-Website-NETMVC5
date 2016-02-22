using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite.Data.Models
{
    public class Order
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId {get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser OrderedBy { get; set; }

        public string Status { get; set; }

        public DateTime DateOrdered { get; set; }
    }
}

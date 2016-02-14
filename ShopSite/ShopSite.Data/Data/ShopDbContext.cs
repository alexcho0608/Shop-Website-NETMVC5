namespace ShopSite.Data.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;

    public class ShopDbContext : IdentityDbContext<User>, IShopDbContext
    {
        public ShopDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Item> Items { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public static ShopDbContext Create()
        {
            return new ShopDbContext();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite.Data.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;

    public class SeedData
    {
        public static Random Rand = new Random();

        public List<Category> Categories;

        public List<Item> Items;

        public ApplicationUser Author { get; set; }

        public SeedData(ApplicationUser author)
        {
            this.Categories = new List<Category>();
            Categories.Add(new Category() { Name = "Laptop" });
            Categories.Add(new Category() { Name = "Monitor" });
            Categories.Add(new Category() { Name = "Phones" });
            Categories.Add(new Category() { Name = "Cameras" });
            Categories.Add(new Category() { Name = "Watches" });
            Categories.Add(new Category() { Name = "TVs" });
            Categories.Add(new Category() { Name = "Coolers" });

            this.Author = author;
            ApplicationUser user = author;

            this.Items = new List<Item>();
            Items.Add(new Item()
            {
                Category = Categories[0],
                Title = "Asus",
                
                Description = "Super cool",
                Pieces = 10,
                Price = 700.00,
                DateCreated = DateTime.Now.AddDays(Rand.Next(-5, 5))
            });
            Items.Add(new Item()
            {
                Category = Categories[2],
                Title = "Samsung",

                Description = "Super cool",
                Pieces = 5,
                Price = 300.00,
                DateCreated = DateTime.Now.AddDays(Rand.Next(-5, 5))
            });
            Items.Add(new Item()
            {
                Category = Categories[2],
                Title = "Phil",

                Description = "Super cool",
                Pieces = 2,
                Price = 1200.00,
                DateCreated = DateTime.Now.AddDays(Rand.Next(-5, 5))
            });
            Items.Add(new Item()
            {
                Category = Categories[4],
                Title = "Swatch",

                Description = "Super cool",
                Pieces = 7,
                Price = 200.00,
                DateCreated = DateTime.Now.AddDays(Rand.Next(-5, 5))
            });
            Items.Add(new Item()
            {
                Category = Categories[6],
                Title = "Ice Cool",

                Description = "Super cool",
                Pieces = 22,
                Price = 56.00,
                DateCreated = DateTime.Now.AddDays(Rand.Next(-5, 5))
            });
            Items.Add(new Item()
            {
                Category = Categories[3],
                Title = "Simens",

                Description = "Super cool",
                Pieces = 22,
                Price = 500.00,
                DateCreated = DateTime.Now.AddDays(Rand.Next(-5, 5))
            });
            Items.Add(new Item()
            {
                Category = Categories[5],
                Title = "Asus",
                
                Description = "Super cool",
                Pieces = 12,
                Price = 700.00,
                DateCreated = DateTime.Now.AddDays(Rand.Next(-5, 5))
            });
        }
    }
}

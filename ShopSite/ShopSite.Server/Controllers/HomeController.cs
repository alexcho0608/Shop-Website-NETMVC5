using AutoMapper.QueryableExtensions;
using Ninject;
using ShopSite.Data.Data;
using ShopSite.Data.Models;
using ShopSite.Server.Models.Home;
using ShopSite.Server.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSite.Server.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        IRepository<Category> categoryRepository;
        //????
        [Inject]
        IRepository<Item> itemRepository;

        public HomeController(IRepository<Category> rCategory, IRepository<Item> rItem)
        {
            this.categoryRepository = rCategory;
            this.itemRepository = rItem;
        }

        public ActionResult Index()
        {
            var categories = categoryRepository.All();
            var items = itemRepository.All();

            ICollection<IndexViewModel> itemList = new List<IndexViewModel>();

            foreach (var category in categories)
            {
                var categoryItem = items.Where(i => i.Category.Id == category.Id);

                var viewCategoryItems = categoryItem.ProjectTo<ItemResponseViewModel>();
                itemList.Add(new IndexViewModel()
                {
                    items = viewCategoryItems,
                    Category = category.Name
                });
            }

            return View(itemList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
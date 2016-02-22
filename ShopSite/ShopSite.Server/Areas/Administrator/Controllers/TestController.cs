using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ShopSite.Data.Models;
using ShopSite.Data.Data;

namespace ShopSite.Server.Areas.Administrator.Controllers
{
    public class TestController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Items_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Item> items = db.Items;
            DataSourceResult result = items.ToDataSourceResult(request, item => new {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                Price = item.Price,
                Pieces = item.Pieces,
                DateCreated = item.DateCreated
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Items_Update([DataSourceRequest]DataSourceRequest request, Item item)
        {
            if (ModelState.IsValid)
            {
                var entity = new Item
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Price = item.Price,
                    Pieces = item.Pieces,
                    DateCreated = item.DateCreated
                };

                db.Items.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { item }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

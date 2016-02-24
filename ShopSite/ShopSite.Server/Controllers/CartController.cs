using Microsoft.AspNet.Identity;
using ShopSite.Data.Data;
using ShopSite.Data.Models;
using ShopSite.Server.Models;
using ShopSite.Server.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSite.Server.Controllers
{
    public class CartController : Controller
    {
        private IRepository<OrderToItem> orderToItemReposiotry;
        private IRepository<Order> orderRepository;
        private IRepository<Item> itemRepository;
        private ShopDbContext db;

        public CartController(IRepository<OrderToItem> repo, IRepository<Order> repo2,
            IRepository<Item> repo3)
        {
            this.orderToItemReposiotry = repo;
            this.orderRepository = repo2;
            this.itemRepository = repo3;
            this.db = new ShopDbContext();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var order = orderRepository.All().Where(o => o.Status == "Pending" && o.UserId == userId);
            if(order.Count()==0)
            {
                return View("Empty");
            }

            var orderId = order.First().Id;

            var orders = from o in db.OrderToItems
                        join e in db.Items on o.ItemId equals e.Id
                        group o by o.ItemId into pg
                        select new OrderViewModel
                        {
                            Item = pg.FirstOrDefault().Item,
                            Total = pg.Count()
                        };
            var viewData = new CartViewModel()
            {
                Orders = orders,
                OrderId = orderId
            };

            return View(viewData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order()
        {
            var form = this.Request.Form;
            var orderId = int.Parse(form["orderId"]);
            var order = orderRepository.All().Where(o => o.Id == orderId).First();
            order.Status = "Completed";
            orderRepository.SaveChanges();

            this.Response.Redirect("/Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert()
        {
            var form = this.Request.Form;

            var userId = User.Identity.GetUserId();
            var order = orderRepository.All().Where(o => o.UserId == userId && o.Status == "Pending");
            int orederId = 0;
            if (order.Count() == 0)
            {
                var newOrder = new Order()
                {
                    UserId = userId,
                    Status = "Pending"
                };
                orderRepository.Add(newOrder);
                orderRepository.SaveChanges();
                orederId = newOrder.Id;
            }
            else
            {
                orederId = order.First().Id;
            }

            var id = int.Parse(form["id"].ToString());
            var item = itemRepository.GetById(id);
            var total = int.Parse(form["total"].ToString());

            for (int i = 0; i < total; i++)
            {
                var orderToItem = new OrderToItem()
                {
                    ItemId = id,
                    OrderId = orederId
                };
                orderToItemReposiotry.Add(orderToItem);
            }
            orderToItemReposiotry.SaveChanges();
            item.Pieces -= total;
            itemRepository.SaveChanges();

            try
            {
                return this.Redirect("/Home");
            }
            catch
            {
                return View();
            }
        }
    }
}

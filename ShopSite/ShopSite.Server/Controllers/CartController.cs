using Microsoft.AspNet.Identity;
using ShopSite.Data.Data;
using ShopSite.Data.Models;
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

        public CartController(IRepository<OrderToItem> repo, IRepository<Order> repo2,
            IRepository<Item> repo3)
        {
            this.orderToItemReposiotry = repo;
            this.orderRepository = repo2;
            this.itemRepository = repo3;
        }
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
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

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

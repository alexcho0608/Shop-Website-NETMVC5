using AutoMapper.QueryableExtensions;
using ShopSite.Data.Data;
using ShopSite.Data.Models;
using ShopSite.Server.Models.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace ShopSite.Server.Controllers
{
    public class ItemController : Controller
    {

        private IRepository<Item> itemRepository;

        public ItemController(IRepository<Item> repository)
        {
            this.itemRepository = repository;
        }

        // GET: SearchItem
        public ActionResult Index(SearchItemRequestModel input)
        {
            return View();
        }

        public ActionResult SearchByWord()
        {
            string word = Request.QueryString["Search"];

            var items = itemRepository.All().Where(i => i.Title.Contains(word) || i.Description.Contains(word));

            this.HttpContext.Cache["data"] = items;

            var viewItems = items.ProjectTo<ItemResponseViewModel>();

            var viewData = new ItemSearchViewModel()
            {
                CurrentPage = 1,
                Items = viewItems.ToList(),
                TotalPages = Math.Ceiling((decimal)viewItems.Count() / 5),
                PageSize = 5
            };

            return View("Index", viewData);
        }

        public ActionResult ViewPage(int page = 1, int pageSize = 5)
        {

            if (this.HttpContext.Cache["data"] == null)
            {
                return RedirectToAction("SearchByWord");
            }

            var count = ((IQueryable<Item>)this.HttpContext.Cache["data"]).Count();

            var items = ((IQueryable<Item>)this.HttpContext.Cache["data"]).OrderBy(e => e.DateCreated).Skip((page - 1) * pageSize).Take(pageSize);
            var viewItems = items.ProjectTo<ItemResponseViewModel>();
            var totalPages = Math.Ceiling((decimal)count / pageSize);

            var data = new ItemSearchViewModel()
            {
                CurrentPage = page,
                PageSize = pageSize,
                Items = viewItems.ToList(),
                TotalPages = totalPages
            };

            return View("Index", data);
        }

        public ActionResult Search(SearchItemRequestModel input)
        {
            int page = 1;
            string word = "";
            if (input.Search != null)
            {
                word = input.Search;
            }

            var items = itemRepository.All().Where(i => i.Title.Contains(word) || i.Description.Contains(word));
            if (input.Category != null)
            {
                var categoriesString = String.Join("", input.Category);
                items = items.Where(i => categoriesString.Contains(i.Category.Name));
            }

            decimal totalPages = Math.Ceiling((decimal)items.Count() / input.PageSize);

            switch (input.Sort)
            {
                case "Description": items = items.OrderBy(e => e.Description).Skip((page - 1) * input.PageSize).Take(input.PageSize); break;
                case "Title": items = items.OrderBy(e => e.Title).Skip((page - 1) * input.PageSize).Take(input.PageSize); break;
                case "Date": items = items.OrderBy(e => e.DateCreated).Skip((page - 1) * input.PageSize).Take(input.PageSize); break;
            }

            var viewItems = items.ProjectTo<ItemResponseViewModel>();

            this.HttpContext.Cache["data"] = items;

            var viewData = new ItemSearchViewModel()
            {
                CurrentPage = page,
                Items = viewItems.ToList(),
                TotalPages = totalPages
            };

            return View("Index", viewData);
        }

        public ActionResult Details(int id)
        {
            var item = itemRepository.GetById(id);

            var viewItem = AutoMapper.Mapper.Map<ItemResponseViewModel>(item);
            return View(viewItem);
        }

        // POST: SearchItem/Create
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
    }
}

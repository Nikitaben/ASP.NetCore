using ASP.NetCore.Data.Interfaces;
using ASP.NetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCore.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IitemRepo _repository;
        public ItemsController(IitemRepo repository)
        {
            _repository = repository;
        }
        // GET: ItemsController
        public ActionResult Index()
        {
            return View(_repository.GetAllitems());
        }

        // GET: ItemsController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.GetItemById(id));
        }

        // GET: ItemsController/Create
        public ActionResult Create()
        {
             return View();
        }

        // POST: ItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item newItem)
        {
            try
            {
                _repository.CreateItem(newItem);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemsController/Edit/5
        public ActionResult Edit(int id)
        {
            var itemToEdit = _repository.GetItemById(id);
            return View(itemToEdit);
        }

        // POST: ItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            try
            {
                _repository.UdateItem(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repository.GetItemById(id));
        }

        // POST: ItemsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CarouselDemo()
        {
            return View();
        }
    }
}

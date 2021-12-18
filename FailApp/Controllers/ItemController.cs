using FailApp.Entities;
using FailApp.Models;
using FailApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Controllers
{
    public class ItemController : Controller
    {
        private ItemRepository ItemService;
        private readonly ILogger<ItemController> _logger;

        public ItemController(ILogger<ItemController> logger, ItemRepository itemService)
        {
            _logger = logger;
            this.ItemService = itemService;
        }

        public IActionResult Index()
        {
            return View(ItemService.Get());
        }

        public IActionResult Create()
        {
            ViewData["data"] = ItemService.Get();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item data)
        {
            ItemService.Save(data);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(ItemService.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(Item data)
        {
            ItemService.Update(data);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(ItemService.Get(id));
        }

        public IActionResult Delete(int id)
        {
            return View(ItemService.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(Item item)
        {
            ItemService.Delete(item.Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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
    public class StockController : Controller
    {
        private StockRepository StockService;
        private ItemRepository itemRepository;
        private readonly ILogger<StockController> _logger;

        public StockController(
            ILogger<StockController> logger, 
            StockRepository StockService,
            ItemRepository itemRepository)
        {
            _logger = logger;
            this.StockService = StockService;
            this.itemRepository = itemRepository;
        }

        public IActionResult Index()
        {
            return View(StockService.Get());
        }

        public IActionResult Create()
        {
            ViewData["data"] = itemRepository.Get();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Stock data)
        {
            StockService.Save(data);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(StockService.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(Stock data)
        {
            StockService.Update(data);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var x = StockService.Get(id);
            return View(StockService.Get(id));
        }

        public IActionResult Delete(int id)
        {
            return View(StockService.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(Stock Stock)
        {
            StockService.Delete(Stock.Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

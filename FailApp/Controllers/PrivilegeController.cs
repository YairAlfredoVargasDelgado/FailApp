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
    public class PrivilegeController : Controller
    {
        private PrivilegeRepository PrivilegeService;
        private readonly ILogger<PrivilegeController> _logger;

        public PrivilegeController(ILogger<PrivilegeController> logger, PrivilegeRepository PrivilegeService)
        {
            _logger = logger;
            this.PrivilegeService = PrivilegeService;
        }

        public IActionResult Index()
        {
            return View(PrivilegeService.Get());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Privilege data)
        {
            PrivilegeService.Save(data);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(PrivilegeService.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(Privilege data)
        {
            PrivilegeService.Update(data);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(PrivilegeService.Get(id));
        }

        public IActionResult Delete(int id)
        {
            return View(PrivilegeService.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(Privilege Privilege)
        {
            PrivilegeService.Delete(Privilege.Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

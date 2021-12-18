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
    public class UserController : Controller
    {
        private UserRepository UserService;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, UserRepository UserService)
        {
            _logger = logger;
            this.UserService = UserService;
        }

        public IActionResult Index()
        {
            return View(UserService.Get());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Users data)
        {
            UserService.Save(data);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(UserService.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(Users data)
        {
            UserService.Update(data);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(UserService.Get(id));
        }

        public IActionResult Delete(int id)
        {
            return View(UserService.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(Users User)
        {
            UserService.Delete(User.Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

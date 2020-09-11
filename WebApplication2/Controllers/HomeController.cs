using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string name="")
        {
            var user = new User1();
            user.age += 30;
            HttpContext.Session.SetString("hello", name);

            return View(model: user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult product()
        {
            /*string content = string.Empty;

            if (HttpContext.Session.Keys.Contains("hello"))
            {
                content = HttpContext.Session.GetString("hello");
                ViewData["content"] = content;
            }*/
            
            Cart cart = new Cart();
            for(int i = 11; i < 14; i++)
            {
            cart.Select(i);
            List<Data> DataList = cart.DataList;
            ViewBag.DataList = DataList;
            
            }
            return View(model:cart);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
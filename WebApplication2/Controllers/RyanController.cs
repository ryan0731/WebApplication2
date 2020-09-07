﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class RyanController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.Keys.Contains("logined"))
            {
                if(HttpContext.Session.GetString("logined") == "true")
                {
                    return LocalRedirect("~/Ryan/product?count=9");
                }
                else
                {
                    return View();
                }
            }
       
            return View();
        }
        public IActionResult product( int count)
        {
            HttpContext.Session.SetString("logined","true");
            ViewData["count"] = count;
            
            return View();
        }
        public IActionResult login(string username, string passwd)
        {
            if (username == "ryan" && passwd == "123456")
                return LocalRedirect("~/Ryan/product?count=9");
            else
                return Redirect("http://www.google.com.tw");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RyanController : Controller
    {
        public IActionResult Index(string error = "")
        {
            if(error != "") ViewBag.Msg = "登入失敗";

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
        //[HttpPost]
        public IActionResult login(string username, string passwd)
        {
            User1 login = new User1();


            //if (username == "ryan" && passwd == "123456")
            //return LocalRedirect("~/Ryan/product?count=9");
            if ( login.loginCheck(username, passwd))
             return LocalRedirect("~/Ryan/product?count=9");
            else 
            { 
                //return Redirect("http://www.google.com.tw");
                
                //return View();
            }
            //return View("Index");

            return LocalRedirect("~/Ryan?error=1") ;
           
            
        }
        public IActionResult register()
            {
                return View();
            }
        public IActionResult regCheck(string username, string passwd, string name,string email)
        {
            User1 reg = new User1();
            if (reg.regCheck(username, passwd, name, email))
                return LocalRedirect("~/Ryan/product?count=9");
            else
                return LocalRedirect("/Ryan/register");
            
        }

    }
}

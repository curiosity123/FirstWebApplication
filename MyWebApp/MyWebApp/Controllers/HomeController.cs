using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.Title = "Łukasz Adach";
            return View("Contact");
        }




        public IActionResult About()
        {
            return View();

        }


        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Dev()
        {
            return View();
        }


        public IActionResult Error()
        {
            Exception ex = new NullReferenceException();

            return View(ex);
        }


        public IActionResult AdminForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminForm(Credentials credentials)
        {
            if (credentials.Login == "admin" && credentials.Password=="password")
            {
                ViewBag.Title = "Witaj Łukasz";
                return View("Index");
            }
            else
            {
                ViewBag.Error = "zły login lub hasło";
                return View();
            }
        }
    }
}

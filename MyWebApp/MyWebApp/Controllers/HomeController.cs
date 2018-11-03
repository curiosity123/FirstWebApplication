using Microsoft.AspNetCore.Mvc;
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
            return View();
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

    }
}

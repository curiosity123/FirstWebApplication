using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using System;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.Title = "Łukasz Adach";
            return RedirectToAction("PostList","Projects");
        }




        public IActionResult About()
        {
            return View();

        }


        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Proj()
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

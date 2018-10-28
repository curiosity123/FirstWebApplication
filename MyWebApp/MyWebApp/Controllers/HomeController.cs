using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Controllers
{
    public class HomeController: Controller
    {

        public IActionResult Index()
        {
            return View(new Test() { Name = "Łukasz" });
        }
    }


    public class Test
    {
        public string Name = "Łukasz";
    }
}

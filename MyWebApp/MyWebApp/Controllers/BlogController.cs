using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApp.Controllers
{
    public class BlogController : Controller
    {

        IBlogRepository repository;
        public BlogController(IBlogRepository repo)
        {
            repository = repo;
        }


        public IActionResult AllPosts()
        {
            return View(repository.GetAll());
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Repositories;

namespace MyWebApp.Controllers
{
    public class ProjectsController : Controller
    {



        IBlogRepository repository;
        public ProjectsController(IBlogRepository repo)
        {
            repository = repo;
        }





        public IActionResult ProjectsList(Category category = 0)
        {
            return View(repository.GetAll(category));
        }


        [HttpGet]
        public IActionResult Project(Guid id)
        {
            var model = repository.Get(id);


            if (model == null)
                return RedirectToAction(nameof(ProjectsList));
            else
                return View(model);
        }



        [HttpPost]
        public IActionResult AddComment(Comment comment, Guid postId)
        {

            repository.AddComment(comment, postId);
            return View("Project", repository.Get(postId));
        }

    }
}
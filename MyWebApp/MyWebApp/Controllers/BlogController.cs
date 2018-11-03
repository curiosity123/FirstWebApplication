using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Repositories;
using System;

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


        public IActionResult PostList()
        {
            return View(repository.GetAll());
        }


        public IActionResult Post(Guid id)
        {
            var model = repository.Get(id);


            if (model == null)
                return RedirectToAction(nameof(PostList));
            else
                return View(model);
        }


        public IActionResult Create(Guid id)
        {
            ViewBag.Title = "Create new post";
            ViewBag.ButtonTitle = "Save post";
            return View("Modify",new Post());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {

            if (ModelState.IsValid)
            {
               // Post newPost = Mapper.Map<Post>(post);

                return RedirectToAction("Details", repository.Create(post));
            }
            else
                return View("Modify");
        }


        public IActionResult Edit(Guid id)
        {
            ViewBag.Title = "Edit your post";
            ViewBag.ButtonTitle = "Confirm";
            return View("Modify",repository.Get(id));
        }


        [HttpPost]
        public IActionResult Edit(Post post)
        {
            return RedirectToAction("Details", repository.Edit(post));
        }
    }
}

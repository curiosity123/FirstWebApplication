using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
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


        public IActionResult Details(Guid id)
        {
            var model = repository.Get(id);


            if (model == null)
                return RedirectToAction(nameof(AllPosts));
            else
                return View(model);
        }


        public IActionResult Create(Guid id)
        {
            return View(new PostDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostDTO post)
        {

            if (ModelState.IsValid)
            {
                Post newPost = Mapper.Map<Post>(post);

                return RedirectToAction("Details", repository.Create(newPost));
            }
            else
                return View();
        }


        public IActionResult Edit(Guid id)
        {
            return View(repository.Get(id));
        }


        [HttpPost]
        public IActionResult Edit(Post post)
        {
            return RedirectToAction("Details", repository.Edit(post));
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Repositories;
using System;


namespace MyWebApp.Controllers
{
    public class BlogController : Controller
    {

        IBlogRepository repository;
        public BlogController(IBlogRepository repo)
        {
            repository = repo;
        }

        [Authorize]
        public IActionResult PostList()
        {
            return View(repository.GetAll());
        }

        [HttpGet]
        public IActionResult Post(Guid id)
        {
            var model = repository.Get(id);


            if (model == null)
                return RedirectToAction(nameof(PostList));
            else
                return View(model);
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment, Guid postId)
        {
            
            repository.AddComment(comment, postId );
            return View("Post",repository.Get(postId));
        }

        [HttpPost]
        public IActionResult RemoveComment(Guid commentId, Guid postId)
        {
            Post toRemove = repository.Get(postId);
            if (toRemove != null)
                repository.RemoveComment(commentId, postId);

            var post = repository.Get(postId);
            return View("Post",post);
        }


        public IActionResult Create(Guid id)
        {
            ViewBag.Title = "Create new post";
            ViewBag.ButtonTitle = "Zapisz";
            return View("Modify", new Post());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {

            if (ModelState.IsValid)
            {
                // Post newPost = Mapper.Map<Post>(post);

                return RedirectToAction("PostList", repository.Create(post));
            }
            else
                return View("Modify");
        }


        public IActionResult Edit(Guid id)
        {
            ViewBag.Title = "Edit your post";
            ViewBag.ButtonTitle = "Zapisz";
            return View("Modify", repository.Get(id));
        }


        public IActionResult Remove(Guid id)
        {
            repository.RemovePost(id);
            return View("PostList", repository.GetAll());
        }


        [HttpPost]
        public IActionResult Edit(Post post)
        {
            repository.Edit(post);
            return RedirectToAction("PostList", repository.GetAll());
        }
    }
}

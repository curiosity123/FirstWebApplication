﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Repositories;
using System;


namespace MyWebApp.Controllers
{
    public class AllPostsController : Controller
    {

        IBlogRepository repository;
        public AllPostsController(IBlogRepository repo)
        {
            repository = repo;
        }


        public IActionResult PostList(Category category=0)
        {
            return View(repository.GetAll(category));
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

            repository.AddComment(comment, postId);
            return RedirectToAction(nameof(Post), new { id=repository.Get(postId).Id });
        }

        [HttpPost]
        public IActionResult Filter(Category category)
        {
            return RedirectToAction("PostList", new { category = category });
        }



        [HttpPost]
        [Authorize]
        public IActionResult RemoveComment(Guid commentId, Guid postId)
        {
            Post toRemove = repository.Get(postId);
            if (toRemove != null)
                repository.RemoveComment(commentId, postId);

            var post = repository.Get(postId);
            return RedirectToAction(nameof(Post), new { id = post.Id });
        }

        [Authorize]
        public IActionResult Create(Guid id)
        {
            ViewBag.Title = "Create new post";
            ViewBag.ButtonTitle = "Zapisz";
            return View("Modify", new Post());
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {

            if (ModelState.IsValid)
            {
                    return RedirectToAction("PostList", repository.Create(post));
            }
            else
                return View("Modify");
        }

        [Authorize]
        public IActionResult Edit(Guid id)
        {
            ViewBag.Title = "Edit your post";
            ViewBag.ButtonTitle = "Zapisz";
            return View("Modify", repository.Get(id));
        }


        [HttpPost]
        [Authorize]
        public IActionResult Edit(Post post)
        {
            repository.Edit(post);
            return RedirectToAction("PostList", repository.GetAll(Category.Wszystkie));
        }

        [Authorize]
        public IActionResult Remove(Guid id)
        {
            repository.RemovePost(id);
            return View("PostList", repository.GetAll(Category.Wszystkie));
        }

    }
}

﻿using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Repositories
{
    public class InMemoryBlogRepository : IBlogRepository
    {

        List<Post> PostList = new List<Post>();

        public InMemoryBlogRepository()
        {
            PostList.Add(new Post { Title = "Flat button w xaml", ShortDescription="Krótki poradnik jak ostylować przycisk pod styl flat...", HtmlContent = "Jakiś kontent" });
            PostList.Add(new Post { Title = "Flat button w xaml", ShortDescription = "Krótki poradnik jak ostylować przycisk pod styl flat...", HtmlContent = "Jakiś kontent" });
            PostList.Add(new Post { Title = "Flat button w xaml", ShortDescription = "Krótki poradnik jak ostylować przycisk pod styl flat...", HtmlContent = "Jakiś kontent" });

        }

        public void AddComment(Comment comment, Guid postId)
        {
            throw new NotImplementedException();
        }

        public Post Create(Post post)
        {
            PostList.Add(post);
            return PostList.FirstOrDefault(x=>x.Id == post.Id);
        }

        public Post Edit(Post post)
        {
            var editedPost = PostList.FirstOrDefault(x => x.Id == post.Id);
            editedPost.Title = post.Title;
            editedPost.Category = post.Category;
            editedPost.ShortDescription = post.ShortDescription;
            editedPost.HtmlContent = post.HtmlContent;
            return editedPost;
        }

        public Post Get(Guid id)
        {
            return PostList.FirstOrDefault(x => x.Id == id);
        }

        public List<Post> GetAll()
        {
            return PostList;
        }

        public List<Post> GetAll(Category category)
        {
            throw new NotImplementedException();
        }

        public void RemoveComment(Guid commentId, Guid postId)
        {
            throw new NotImplementedException();
        }

        public void RemovePost(Guid id)
        {
            PostList.RemoveAll(x => x.Id == id);
        }
    }
}

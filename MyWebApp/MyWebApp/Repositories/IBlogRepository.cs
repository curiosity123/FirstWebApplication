using MyWebApp.Models;
using System;
using System.Collections.Generic;

namespace MyWebApp.Repositories
{
    public interface IBlogRepository
    {
        Post Create(Post post);
        void RemovePost(Guid id);
        List<Post> GetAll(Category category);
        Post Get(Guid id);
        Post Edit(Post post);
        void AddComment(Comment comment, Guid postId);
        void RemoveComment(Guid commentId, Guid postId);
    }
}

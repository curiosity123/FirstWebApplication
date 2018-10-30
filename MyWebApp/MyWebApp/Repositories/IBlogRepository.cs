using MyWebApp.Models;
using System;
using System.Collections.Generic;

namespace MyWebApp.Repositories
{
    public interface IBlogRepository
    {


        void AddNewPost(Post post);
        void RemovePost(Guid id);
        List<Post> GetAll();     


    }
}

using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Repositories
{
    interface IBlogRepository
    {


        void AddNewPost(Post post);
        void RemovePost(Guid id);
        List<Post> GetAll();     


    }
}

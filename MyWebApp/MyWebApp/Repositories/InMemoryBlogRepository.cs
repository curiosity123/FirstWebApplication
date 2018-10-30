using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Repositories
{
    public class InMemoryBlogRepository: IBlogRepository
    {

        List<Post> PostList = new List<Post>();

        public InMemoryBlogRepository()
        {

        }

        public void AddNewPost(Post post)
        {
            PostList.Add(post);
        }

        public List<Post> GetAll()
        {
            return PostList;
        }

        public void RemovePost(Guid id)
        {
            PostList.RemoveAll(x => x.Id == id);
        }
    }
}

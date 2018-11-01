using MyWebApp.Models;
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
            PostList.Add(new Post { Title = "Post testowy", Content = "Jakiś kontent" });
            PostList.Add(new Post { Title = "Post testowy1", Content = "Jakiś kontent1" });
            PostList.Add(new Post { Title = "Post testowy2", Content = "Jakiś kontent2" });
        }

        public Post Create(Post post)
        {
            PostList.Add(post);
            return PostList.FirstOrDefault(x=>x.Id == post.Id);
        }

        public Post Get(Guid id)
        {
            return PostList.FirstOrDefault(x => x.Id == id);
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

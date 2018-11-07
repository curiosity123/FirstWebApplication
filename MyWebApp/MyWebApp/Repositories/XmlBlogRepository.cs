using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApp.Repositories
{
    public class XmlBlogRepository : IBlogRepository
    {

        List<Post> PostList = new List<Post>();

        public XmlBlogRepository()
        {
       

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

        public void RemovePost(Guid id)
        {
            PostList.RemoveAll(x => x.Id == id);
        }

     

    }
}

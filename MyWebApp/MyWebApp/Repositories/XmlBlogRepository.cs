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
            PostList = XmlDataBase<Post>.Load();
            if (PostList == null)
                PostList = new List<Post>();
        }

        public Post Create(Post post)
        {
            PostList.Add(post);
            XmlDataBase<Post>.Save(PostList);
            return PostList.FirstOrDefault(x => x.Id == post.Id);
        }

        public Post Edit(Post post)
        {
            var editedPost = PostList.FirstOrDefault(x => x.Id == post.Id);
            editedPost.Title = post.Title;
            editedPost.Category = post.Category;
            editedPost.ShortDescription = post.ShortDescription;
            editedPost.HtmlContent = post.HtmlContent;
            XmlDataBase<Post>.Save(PostList);
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
            XmlDataBase<Post>.Save(PostList);
        }



    }
}

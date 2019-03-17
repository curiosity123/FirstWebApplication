using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApp.EF;
using MyWebApp.Models;

namespace MyWebApp.Repositories
{
    public class MsSqlRepository : IBlogRepository
    {
        PostsContext dbContext;

        public MsSqlRepository(PostsContext _context)
        {
            dbContext = _context;
        }



        public void AddComment(Comment comment, Guid postId)
        {
            var post = dbContext.Posts.Where(x => x.Id == postId).FirstOrDefault();
            if (post != null)
            {

                post.Comments.Add(comment);
                dbContext.SaveChanges();
            }
        }

        public Post Create(Post post)
        {

            dbContext.Posts.Add(post);
            dbContext.SaveChanges();
            return null;
        }

        public Post Edit(Post post)
        {
            var u = (from x in dbContext.Posts where x.Id == post.Id select x).Include("Comments").FirstOrDefault();
            u.Title = post.Title;
            u.BackgroundContent = post.BackgroundContent;
            u.ShortDescription = post.ShortDescription;
            u.HtmlContent = post.HtmlContent;
            u.Category = post.Category;
            u.IsProject = post.IsProject;
            u.IsPublished = post.IsPublished;
            dbContext.SaveChanges();
            return u;
        }

        public Post Get(Guid id)
        {
            var u = (from x in dbContext.Posts where x.Id == id select x).Include("Comments").FirstOrDefault();
            return u;
        }

        public List<Post> GetAll(Category category)
        {
            if (category != 0)
                return dbContext.Posts.ToList().Where(x => x.Category == category).ToList().OrderBy(x => x.Created).Reverse().ToList(); 
            else
                return dbContext.Posts.ToList().OrderBy(x => x.Created).Reverse().ToList();
        }

        public void RemoveComment(Guid commentId, Guid postId)
        {
            var post = dbContext.Posts.Where(x => x.Id == postId).FirstOrDefault();
            if (post != null)
            {
                var c = post.Comments.Where(x => x.Id == commentId).FirstOrDefault();
                if (c != null)
                {
                    post.Comments.Remove(c);
                    dbContext.Comments.Remove(c);
                    dbContext.SaveChanges();
                }
            }
        }

        public void RemovePost(Guid id)
        {

            var post = dbContext.Posts.Where(x => x.Id == id).Include("Comments").FirstOrDefault();
            if (post != null)
            {
                var comments = post.Comments;

                dbContext.Posts.Remove(post);
                dbContext.Comments.RemoveRange(comments);
                dbContext.SaveChanges();
            }

        }
    }
}

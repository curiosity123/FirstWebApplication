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

        public MsSqlRepository(PostsContext _context)
        {
            dbContext = _context;
        }

        PostsContext dbContext;





        public void AddComment(Comment comment, Guid postId)
        {
            throw new NotImplementedException();
        }

        public Post Create(Post post)
        {

            dbContext.Posts.Add(post);
            dbContext.SaveChanges();
            return null;
        }

        public Post Edit(Post post)
        {
            throw new NotImplementedException();
        }

        public Post Get(Guid id)
        {
            var u = (from x in dbContext.Posts where x.Id == id select x).Include("Posts.Comments").FirstOrDefault();
            return u;
        }

        public List<Post> GetAll()
        {
            return dbContext.Posts.ToList();

        }

        public void RemoveComment(Guid commentId, Guid postId)
        {
            throw new NotImplementedException();
        }

        public void RemovePost(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

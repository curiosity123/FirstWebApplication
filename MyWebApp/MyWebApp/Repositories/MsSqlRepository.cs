using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public PostsContext dbContext { get; private set; }





        public void AddComment(Comment comment, Guid postId)
        {
            throw new NotImplementedException();
        }

        public Post Create(Post post)
        {
            throw new NotImplementedException();
        }

        public Post Edit(Post post)
        {
            throw new NotImplementedException();
        }

        public Post Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAll()
        {
            throw new NotImplementedException();
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

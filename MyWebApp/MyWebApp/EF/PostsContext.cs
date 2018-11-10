using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.EF
{
    public class PostsContext : DbContext
    {

        public PostsContext(DbContextOptions<PostsContext> options): base(options)
        {

        }



        public DbSet<Post> Users { get; set; }


    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.EF
{
    public class PostsContext : IdentityDbContext<AdminUser>
    {

        public PostsContext(DbContextOptions<PostsContext> options): base(options)
        {

        }



        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}

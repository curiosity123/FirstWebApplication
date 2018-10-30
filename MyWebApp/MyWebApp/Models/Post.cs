using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Models
{
    public class Post
    {
        public DateTime Created { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Published { get; set; }
    }
}

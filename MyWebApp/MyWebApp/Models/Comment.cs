using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }


        public Comment()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
        }
    }
}

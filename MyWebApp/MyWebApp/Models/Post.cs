using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        public Category Category { get; set; }
        public DateTime Created { get; set; }
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        [Required, MaxLength(10)]
        public string Title { get; set; }
        public string HtmlContent { get; set; }


        public Post()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
            Category = Category.Other;
            HtmlContent = "";
            Title = "";
        }
    }
}

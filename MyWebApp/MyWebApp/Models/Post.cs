using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        public Category Category { get; set; }
        public DateTime Created { get; set; }
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        [Required, MaxLength(500)]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string HtmlContent { get; set; }
        public List<Comment> Comments{get;set;}
        public bool IsProject { get; set; }
        public bool IsPublished { get; set; }


        public Post()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
            Category = Category.Wszystkie;
            HtmlContent = "";
            Title = "";
            Comments = new List<Comment>();
        }
    }
}

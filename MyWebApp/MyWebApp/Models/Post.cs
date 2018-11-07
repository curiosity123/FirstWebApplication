using System;
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Models
{
    public class PostDTO
    {
        [Display(Name = "enter Title")]
        [DataType(DataType.Text)]
        [Required, MaxLength(10)]
        public string Title { get; set; }
        public Category Type { get; set; }
    }
}

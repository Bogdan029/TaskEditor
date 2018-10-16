using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskEditor.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Fill out, please")]
        public string Name { get; set; }
        public string Surname { get; set; }

        [Required(ErrorMessage = "Fill out, please")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Fill out, please")]
        public string Password { get; set; }
    }
}
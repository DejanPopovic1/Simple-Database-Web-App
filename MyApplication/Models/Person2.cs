using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//This is added in so that the "Required" annotations below work
using System.ComponentModel.DataAnnotations.Schema;//This is added so that the Key annotation works

namespace MyApplication.Models
{
    public class Person2
    {
        [Required(ErrorMessage = "Required field")]
        public String Id { get; set; }
        [Required(ErrorMessage = "Required field")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Required field")]
        public String Surname { get; set; }
        [Required(ErrorMessage = "Required field")]
        public String Password { get; set; }
        [Required(ErrorMessage = "Required field")]
        public DateTime LastLogin { get; set; }
    }
}
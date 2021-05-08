using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//This is added in so that the "Required" annotations below work


namespace MyApplication.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Required field")]
        public String Username { get; set; }
        [Required(ErrorMessage = "Required field")]
        public String Password { get; set; }
    }
}
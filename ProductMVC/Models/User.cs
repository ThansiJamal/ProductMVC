using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductMVC.Models
{
    public class User
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = " Please Enter Username")]
        [StringLength(10, MinimumLength = 3)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 7, ErrorMessage = "Password must be string ang maximum length should be 7")]
        public string Password { get; set; }
    }
}
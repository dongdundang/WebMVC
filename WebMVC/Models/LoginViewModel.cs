using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { set; get; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        [Required]
        public bool RememberMe { set; get; }
    }
}
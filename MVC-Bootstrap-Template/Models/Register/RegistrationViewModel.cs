using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Bootstrap_Template.Models.Register
{
    public class RegistrationViewModel
    {
        [Display(Name = "Username")]
        public string Username { get; set; }
        
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }


        [Display(Name = "ConfirmPassword")]
        public string PasswordConfirm { get; set; }

    }
}
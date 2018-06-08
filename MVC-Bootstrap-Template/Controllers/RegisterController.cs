using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MVC_Bootstrap_Template.Models.Register;

namespace MVC_Bootstrap_Template.Controllers
{
    public class RegisterController : Controller
    { 

        [HttpGet]
        public ActionResult Index()
        {
            RegistrationViewModel form = new RegistrationViewModel();
            
            return View(form);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(RegistrationViewModel form_data)
        {

            if(String.IsNullOrWhiteSpace(form_data.Username))
            {
                ModelState.AddModelError("Username", "Username is required");
            }

            if(String.IsNullOrWhiteSpace(form_data.Email))
            {
                ModelState.AddModelError("Email", "Email address is required");
            }
            else
            { 
                MailAddress testEmail = null;
                try
                {
                    testEmail = new MailAddress(form_data.Email);
                } catch(FormatException fEX)
                {
                    ModelState.AddModelError("Email", "Email is not valid");
                }
            }

            if(String.IsNullOrWhiteSpace(form_data.Password))
            {
                ModelState.AddModelError("Password", "Password is required");
            }


            if (String.IsNullOrWhiteSpace(form_data.PasswordConfirm))
            {
                ModelState.AddModelError("PasswordConfirm", "Password confirmation is required");
            }

            if(!form_data.Password.Equals(form_data.PasswordConfirm))
            {
                ModelState.AddModelError("PasswordConfirm", "Password confirmation does not match password");
            }

            if(!ModelState.IsValid)
            {
                return View(form_data);
            } else
            {
                //Process form via service
            }

            return View();
        }

    }
}

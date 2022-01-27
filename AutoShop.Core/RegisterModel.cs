using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoShop.Core
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Password)]        
        [Display(Name = "Confirm Password")]        
        [Compare("Password", ErrorMessage = "password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }
    }
}

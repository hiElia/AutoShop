using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Models
{
    public class RegModel
    {
        //public int UsersId { get; set; }
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

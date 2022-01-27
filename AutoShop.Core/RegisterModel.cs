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
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Comfirm Password")]
        [Compare("password", ErrorMessage = "password and confirmation password" +
            "do not match")]

        public string ConfirmPassword { get; set; }
    }
}

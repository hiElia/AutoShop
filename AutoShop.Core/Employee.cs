using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoShop.Core
{
    public class Employee
    {
      
        public int id { get; set; }
        [Required, StringLength(50)]
        public string name { get; set; }
        

    }
}

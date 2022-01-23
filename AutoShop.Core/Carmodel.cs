using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoShop.Core
{
    public class Carmodel
    {
       
            public int id { get; set; }
            [Required, StringLength(50)]   
            public string brand { get; set; }
            [Required, StringLength(50)]  
            public string model { get; set; }
            public int price { get; set; }
        
    }
}

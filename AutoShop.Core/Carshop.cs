﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AutoShop.Core
{
    public class Carshop
    {
            public int id { get; set; }
            private List<Employee> employees { get; set; }
            private List<Carmodel> carmodels { get; set; }
            public List<Sale> sales { get; set; }
        
    }
}

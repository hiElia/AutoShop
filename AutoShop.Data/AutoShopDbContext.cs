using AutoShop.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoShop.Data
{
    public class AutoShopDbContext : DbContext
    {
        public DbSet<Employee> employees { get; set; }
        public DbSet<Sale> sales { get; set; }
        public DbSet<Carmodel> carmodels { get; set; }
        public DbSet<Carshop> carshops { get; set; }
    }
}

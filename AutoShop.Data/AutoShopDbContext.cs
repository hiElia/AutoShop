using AutoShop.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoShop.Data
{
    public class AutoShopDbContext : IdentityDbContext
    {
        public AutoShopDbContext(DbContextOptions<AutoShopDbContext> options)
         : base(options)
        {
           
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Sale> sales { get; set; }
        public DbSet<Carmodel> carmodels { get; set; }
        public DbSet<Carshop> carshops { get; set; }
    }
}

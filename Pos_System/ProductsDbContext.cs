using Pos_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pos_System
{
    public class ProductsDbContext : DbContext
    {

        public ProductsDbContext() : base("name=POSDB")
        {
            Database.SetInitializer<ProductsDbContext>(new PosInitializer());
        }

        public DbSet<Product> Products { get; set; }  
        public DbSet<Category> Category { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }


}
using Shop1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shop1.Context
{
    public class ShopDbContext:DbContext
    {
        public ShopDbContext()
            : base("ShopDBConnectionString")
        {

        }

        public DbSet<Products> Productss { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Mark> Marks { get; set; }
    }
}
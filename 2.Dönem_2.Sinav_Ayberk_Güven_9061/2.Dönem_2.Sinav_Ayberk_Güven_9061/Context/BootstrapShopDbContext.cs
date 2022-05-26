using _2.Dönem_2.Sinav_Ayberk_Güven_9061.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _2.Dönem_2.Sinav_Ayberk_Güven_9061.Context
{
    public class BootstrapShopDbContext:DbContext
    {
        public BootstrapShopDbContext()
            : base("BootstrapShopDBConnectionString")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
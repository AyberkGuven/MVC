using DbSinav1_9061_Ayberk_Güven.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DbSinav1_9061_Ayberk_Güven.Context
{
    public class SinavDbContext:DbContext
    {
        public SinavDbContext()
            : base("Sinav9061AyberkDBConnectionString")
        {

        }

        public DbSet<Products> Productss { get; set; }
        public DbSet<Details> Detailss { get; set; }
    }
}
using FirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstMVC.Context
{
    public class DbMesaj:DbContext
    {
        public DbMesaj()
            : base("AistekDBConnectionString")
        {

        }
        public DbSet<Mesaj> Mesajs { get; set; }
    }
}
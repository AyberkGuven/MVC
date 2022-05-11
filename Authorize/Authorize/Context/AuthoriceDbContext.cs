using Authorize.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Authorize.Context
{
    public class AuthorizeDbContext:DbContext
    {
        public AuthorizeDbContext()
            : base("AuthorizeDBConnectionString")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
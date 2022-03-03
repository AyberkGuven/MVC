using StudentsFollow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsFollow.Context
{
    public class StudentFollowDbContext:DbContext
    {
        public StudentFollowDbContext()
            : base("StudentFollowsDBConnectionString")
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
    }
}
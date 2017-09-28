using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Context : DbContext
    {
        public Context()
            : base("name=StudentsDb")
        {
            Database.SetInitializer<Context>(null);


        }

        public DbSet<Students> Students { get; set; }
        public DbSet<StdClass> Classes { get; set; }
        public DbSet<DepModel> Department { get; set; }
        public DbSet<TeacherModel> Teacher { get; set; }

    }
}
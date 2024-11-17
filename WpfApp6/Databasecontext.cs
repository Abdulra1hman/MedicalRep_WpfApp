using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace WpfApp6
{
    public class Databasecontext : DbContext
    {
       public DbSet<User> Users { get; set; }

      public DbSet<Course>COURSES { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EksamensStats.Model
{
    public class StudentContext : DbContext
    {
        public StudentContext()
            : base("Defaultconnection")
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentStats> StudentStatses { get; set; }
    }
}

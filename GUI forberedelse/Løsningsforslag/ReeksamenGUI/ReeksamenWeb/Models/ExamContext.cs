using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReeksamenWeb.Models
{
    public class ExamContext : DbContext
    {
        public ExamContext()
            : base("Defaultconnection")
        {
        }
        public DbSet<EksamensSet> EksamensSets { get; set; }
       
    }
}
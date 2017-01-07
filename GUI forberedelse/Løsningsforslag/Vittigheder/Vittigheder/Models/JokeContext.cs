using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vittigheder.Models
{
    public class JokeContext : DbContext
    {
        public JokeContext()
            : base("Defaultconnection")
        {
        }
        public DbSet<Joke> Jokes { get; set; }
    }
}

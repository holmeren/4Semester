using System.Data.Entity;

namespace vittigheder_web3.Models
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

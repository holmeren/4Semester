using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vittigheder.Models
{
    public class Joke
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string JokeString { get; set; }
        public string Source { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}

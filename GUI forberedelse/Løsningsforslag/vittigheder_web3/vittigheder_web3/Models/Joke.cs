using System;
using System.Collections.Generic;

namespace vittigheder_web3.Models
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

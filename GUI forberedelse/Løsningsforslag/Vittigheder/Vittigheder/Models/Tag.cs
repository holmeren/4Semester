namespace Vittigheder.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagString { get; set; }
        public Joke Joke { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BlogContext())
            {
                //Laver og gemmer ny blog
                Console.Write("Enter a name for the blog ");
                var name = Console.ReadLine();

                var blog = new Blog {Name = name};
                db.Blogs.Add(blog);
                db.SaveChanges();

                //Viser alle blog fra en database
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("Alle blogge in databasen: ");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any jey to exit...");
                Console.ReadKey();

            }
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }


}

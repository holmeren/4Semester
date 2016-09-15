using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

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

                Console.Write("Enter a organization name: ");
                var nameOrg = Console.ReadLine();

                var org = new Organization {OrganizationName = nameOrg};
                db.Organizations.Add(org);
                db.SaveChanges();

                var queryOrg = from b in db.Organizations
                            orderby b.OrganizationName
                            select b;

                Console.WriteLine("Alle Organizationsnavne in databasen: ");
                foreach (var item in queryOrg)
                {
                    Console.WriteLine(item.OrganizationName);
                }

                Console.Write("Enter a Username: ");
                var nameUser = Console.ReadLine();
                Console.Write("Enter a : ");
                var nameDis = Console.ReadLine();

                var user = new User { DisplayName = nameDis, Organization = org, Username = nameUser};
                db.Users.Add(user);
                db.SaveChanges();

                var queryUser = from b in db.Users
                               orderby b.DisplayName
                               select b;

                Console.WriteLine("All Users in databasen: ");
                foreach (var item in queryUser)
                {
                    Console.Write("Display name: ");
                    Console.WriteLine(item.DisplayName);
                    Console.Write("Username: ");
                    Console.WriteLine(item.Username);
                    Console.Write("Organization: ");
                    Console.WriteLine(item.Organization.OrganizationName);
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
        public string Url { get; set; }
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

    public class User
    {
        [Key]
        public string Username { get; set; }
        public string DisplayName { get; set; }

        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
    }

    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
    }

    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DisplayName)
                .HasColumnName("display_name");
        }
    }


}

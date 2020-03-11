using System.Data.Entity;

namespace CodeFirstPlutoProject1
{
    public class PlutoProjectContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}

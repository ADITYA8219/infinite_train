using System.Data.Entity;

namespace MoviesApp.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() : base("MoviesDB") { }

        public DbSet<Movie> Movies { get; set; }
    }
}

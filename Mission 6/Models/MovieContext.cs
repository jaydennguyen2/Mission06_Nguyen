using Microsoft.EntityFrameworkCore;

namespace Mission_6.Models
{
    public class MovieContext : DbContext
    {
        // Constructor to configure the database context with options
        public MovieContext(DbContextOptions<MovieContext> options) : base (options) 
        {
        }

        // DbSet representing the Movies table in the database
        public DbSet<Movie> Movies { get; set; }

        // DbSet representing the Categories table in the database
        public DbSet<Category> Categories { get; set; }

       
    }
}


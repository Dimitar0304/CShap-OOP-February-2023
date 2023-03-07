using Microsoft.EntityFrameworkCore;

namespace test.Data
{
    public class MovieWorldContext:DbContext
    {
        public MovieWorldContext(DbContextOptions<MovieWorldContext> options):base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<MovieCatalog> MovieCatalogs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

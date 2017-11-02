using AlbumsRegistry.Model;
using Microsoft.EntityFrameworkCore;

namespace AlbumsRegistry.WebApi.DataAccess
{
    public class AlbumsRegistryDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Album> Albums { get; set; }

        public AlbumsRegistryDbContext(DbContextOptions<AlbumsRegistryDbContext> options) : base(options)
        {
            
        }
    }
}

using AlbumsRegistry.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumsRegistry.Repository
{
    public class AlbumsRegistryDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Album> Albums { get; set; }
    }
}

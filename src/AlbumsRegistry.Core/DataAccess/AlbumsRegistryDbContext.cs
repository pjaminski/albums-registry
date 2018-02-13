using System.Configuration;
using System.Data.Entity;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.DataAccess
{
    public class AlbumsRegistryDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<AdminMode> AdminMode { get; set; }

        public AlbumsRegistryDbContext()
        {
            Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["AlbumsRegistryDb"].ConnectionString;
        }
    }
}

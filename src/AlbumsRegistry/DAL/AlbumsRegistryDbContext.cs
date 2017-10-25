using AlbumsRegistry.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlbumsRegistry.DAL
{
    public class AlbumsRegistryDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Album> Albums { get; set; }
    }
}
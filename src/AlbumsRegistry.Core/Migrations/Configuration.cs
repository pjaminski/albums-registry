using AlbumsRegistry.Core.Models;
using System.Data.Entity.Migrations;
using AlbumsRegistry.Core.Services;

namespace AlbumsRegistry.Core.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.AlbumsRegistryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.AlbumsRegistryDbContext context)
        {
            var adminModeInfo = new AdminMode
            {
                PasswordCore = Cipher.Encrypt("renewal"),
                IsActive = false
            };

            context.AdminMode.AddOrUpdate(a => a.PasswordCore, adminModeInfo);
            context.SaveChanges();
        }
    }
}

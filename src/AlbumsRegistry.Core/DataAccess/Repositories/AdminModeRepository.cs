using System.Data.Entity.Migrations;
using System.Linq;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.DataAccess.Repositories
{
    public class AdminModeRepository
    {
        private readonly AlbumsRegistryDbContext _dbContext;

        public AdminModeRepository()
        {
            _dbContext = new AlbumsRegistryDbContext();
        }

        public AdminMode GetAdminModeInfo()
        {
            return _dbContext.AdminMode.FirstOrDefault();
        }

        public void SaveAdminModeInfo(AdminMode adminMode)
        {
            _dbContext.AdminMode.AddOrUpdate(a => a.PasswordCore, adminMode);
            _dbContext.SaveChanges();
        }
    }
}
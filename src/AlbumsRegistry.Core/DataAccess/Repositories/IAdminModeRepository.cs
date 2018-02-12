using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.DataAccess.Repositories
{
    public interface IAdminModeRepository
    {
        AdminMode GetAdminModeInfo();

        void SaveAdminModeInfo(AdminMode adminMode);
    }
}
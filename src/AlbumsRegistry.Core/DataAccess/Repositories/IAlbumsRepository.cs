using System.Collections.Generic;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.DataAccess.Repositories
{
    public interface IAlbumsRepository
    {
        void CreateAlbum(Album album);

        IEnumerable<Album> GetAlbums();

        Album GetAlbumById(int id);

        void UpdateAlbum(Album album);
    }
}

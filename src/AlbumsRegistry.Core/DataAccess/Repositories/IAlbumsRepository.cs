using System.Collections.Generic;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.DataAccess.Repositories
{
    public interface IAlbumsRepository
    {
        bool CreateAlbum(Album album);

        IEnumerable<Album> GetAlbums();

        Album GetAlbumById(int id);

        Album UpdateAlbum(Album album);
    }
}

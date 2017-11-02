using System.Collections.Generic;
using AlbumsRegistry.Model;

namespace AlbumsRegistry.WebApi.DataAccess.Repositories
{
    public interface IAlbumRepository
    {
        bool CreateAlbum(Album album);

        IEnumerable<Album> GetAlbums();

        Album GetAlbumById(int id);

        Album UpdateAlbum(Album album);
    }
}

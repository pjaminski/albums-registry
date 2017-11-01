using System.Collections.Generic;
using AlbumsRegistry.Repository.Models;

namespace AlbumsRegistry.Repository.Repositories
{
    public interface IAlbumRepository
    {
        bool CreateAlbum(Album album);

        IEnumerable<Album> GetAlbums();

        Album GetAlbumById(int id);

        Album UpdateAlbum(Album album);
    }
}

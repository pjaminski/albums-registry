using System.Collections.Generic;
using AlbumsRegistry.Model;

namespace AlbumsRegistry.WebApi.DataAccess.Repositories
{
    public interface IArtistRepository
    {
        bool CreateArtist(Artist artist);

        IEnumerable<Artist> GetArtists();

        Artist GetArtistById(int id);

        Artist UpdateArtist(Artist artist);
    }
}

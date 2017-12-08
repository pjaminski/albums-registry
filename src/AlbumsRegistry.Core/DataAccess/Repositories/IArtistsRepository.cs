using System.Collections.Generic;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.DataAccess.Repositories
{
    public interface IArtistsRepository
    {
        bool CreateArtist(Artist artist);

        IEnumerable<Artist> GetArtists();

        Artist GetArtistById(int id);

        Artist UpdateArtist(Artist artist);
    }
}

using System.Collections.Generic;
using AlbumsRegistry.Repository.Models;

namespace AlbumsRegistry.Repository.Repositories
{
    public interface IArtistRepository
    {
        bool CreateArtist(Artist artist);

        IEnumerable<Artist> GetArtists();

        Artist GetArtistById(int id);

        Artist UpdateArtist(Artist artist);
    }
}

using System.Collections.Generic;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.DataAccess.Repositories
{
    public interface IArtistsRepository
    {
        void CreateArtist(Artist artist);

        IEnumerable<Artist> GetArtists();

        Artist GetArtistById(int id);

        void UpdateArtist(Artist artist);
    }
}

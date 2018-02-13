using System.Collections.Generic;
using System.Linq;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.DataAccess.Repositories
{
    public class ArtistsRepository : IArtistsRepository
    {
        private readonly AlbumsRegistryDbContext _dbContext;

        public ArtistsRepository()
        {
            _dbContext = new AlbumsRegistryDbContext();
        }

        public void CreateArtist(Artist artist)
        {
            _dbContext.Artists.Add(artist);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Artist> GetArtists()
        {
            return _dbContext.Artists.OrderBy(a => a.Name).ToList();
        }

        public Artist GetArtistById(int id)
        {
            return _dbContext.Artists.SingleOrDefault(a => a.Id == id);
        }

        public void UpdateArtist(Artist artist)
        {
            var artistBeforeChanges = GetArtistById(artist.Id);

            if (artistBeforeChanges != null)
            {
                artistBeforeChanges.Name = artist.Name;
                artistBeforeChanges.City = artist.City;
                _dbContext.SaveChanges();
            }
        }
    }
}

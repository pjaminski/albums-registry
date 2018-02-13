using System.Collections.Generic;
using System.Linq;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.DataAccess.Repositories
{
    public class AlbumsRepository : IAlbumsRepository
    {
        private readonly AlbumsRegistryDbContext _dbContext;

        public AlbumsRepository()
        {
            _dbContext = new AlbumsRegistryDbContext();
        }

        public void CreateAlbum(Album album)
        {
            _dbContext.Albums.Add(album);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Album> GetAlbums()
        {
            return _dbContext.Albums.Include("Artist").Include("Publisher")
                .OrderBy(a => a.Artist.Name)
                .ThenBy(a => a.ReleaseYear)
                .ToList();
        }

        public Album GetAlbumById(int id)
        {
            return _dbContext.Albums.Include("Artist").Include("Publisher").SingleOrDefault(a => a.Id == id);
        }

        public void UpdateAlbum(Album album)
        {
            var albumBeforeChanges = GetAlbumById(album.Id);

            if (albumBeforeChanges != null)
            {
                albumBeforeChanges.ArtistId = album.ArtistId;
                albumBeforeChanges.PublisherId = album.PublisherId;
                albumBeforeChanges.ReleaseYear = album.ReleaseYear;
                albumBeforeChanges.Title = album.Title;
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Album> GetAlbumsBySearchTerm(string searchTerm)
        {
            var searchString = searchTerm.ToLower().Trim();
            return _dbContext.Albums.Where(a => a.Title.ToLower().Contains(searchString) || a.Artist.Name.ToLower().Contains(searchString))
                                    .OrderBy(a => a.Artist.Name)
                                    .ThenBy(a => a.ReleaseYear)
                                    .ToList();
        }
    }
}

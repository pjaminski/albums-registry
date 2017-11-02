using System.Collections.Generic;
using AlbumsRegistry.Model;

namespace AlbumsRegistry.WebApi.DataAccess.Repositories.FakeRepositories
{
    public class FakeAlbumRepository : IAlbumRepository
    {
        private Dictionary<int, Album> _albumsDictionary;

        public FakeAlbumRepository()
        {
            Seed();
        }

        public bool CreateAlbum(Album album)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Album> GetAlbums()
        {
            return _albumsDictionary.Values;
        }

        public Album GetAlbumById(int id)
        {
            return _albumsDictionary[id];
        }

        public Album UpdateAlbum(Album album)
        {
            throw new System.NotImplementedException();
        }

        private void Seed()
        {
            _albumsDictionary = new Dictionary<int, Album>();

            var album1 = new Album
            {
                Artist = new Artist {City = "Warszawa", Id = 1, Name = "Tede"},
                Id = 1,
                Publisher = new Publisher {City = "Warszawa", Id = 1, Name = "Wielkie Joł"},
                ReleaseYear = 2004,
                Title = "Hajs Hajs Hajs",
                TracksCount = 22
            };

            _albumsDictionary.Add(album1.Id, album1);

            var album2 = new Album
            {
                Artist = new Artist { City = "Poznań", Id = 3, Name = "Paluch" },
                Id = 2,
                Publisher = new Publisher { City = "Warszawa", Id = 3, Name = "Wielkie Joł" },
                ReleaseYear = 2017,
                Title = "Złota owca",
                TracksCount = 14
            };

            _albumsDictionary.Add(album2.Id, album2);

            var album3 = new Album
            {
                Artist = new Artist { City = "Warszawa", Id = 1, Name = "Tede" },
                Id = 3,
                Publisher = new Publisher { City = "Opole", Id = 2, Name = "Step Records" },
                Title = "Album3",
                TracksCount = 22
            };

            _albumsDictionary.Add(album3.Id, album3);

            var album4 = new Album
            {
                Artist = new Artist { City = "Warszawa", Id = 3, Name = "Vienio & Pele" },
                Id = 4,
                Publisher = new Publisher { City = "Warszawa", Id = 1, Name = "Alkopoligamia" },
                ReleaseYear = 2013,
                Title = "Autentyk 2",
            };

            _albumsDictionary.Add(album4.Id, album4);
        }
    }
}

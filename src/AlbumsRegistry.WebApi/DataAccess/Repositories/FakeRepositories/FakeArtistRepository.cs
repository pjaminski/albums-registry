using System;
using System.Collections.Generic;
using AlbumsRegistry.Model;

namespace AlbumsRegistry.WebApi.DataAccess.Repositories.FakeRepositories
{
    public class FakeArtistRepository : IArtistRepository
    {
        private Dictionary<int, Artist> _artistsDictionary;

        public FakeArtistRepository()
        {
            Seed();
        }

        public bool CreateArtist(Artist artist)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Artist> GetArtists()
        {
            return _artistsDictionary.Values;
        }

        public Artist GetArtistById(int id)
        {
            return _artistsDictionary[id];
        }

        public Artist UpdateArtist(Artist artist)
        {
            throw new NotImplementedException();
        }

        private void Seed()
        {
            _artistsDictionary = new Dictionary<int, Artist>();

            var artist1 = new Artist
            {
                City = "Warszawa",
                Id = 1,
                Name = "Tede"
            };

            _artistsDictionary.Add(artist1.Id, artist1);

            var artist2 = new Artist
            {
                City = "Warszawa",
                Id = 2,
                Name = "Chada"
            };

            _artistsDictionary.Add(artist2.Id, artist2);

            var artist3 = new Artist
            {
                City = "Poznań",
                Id = 3,
                Name = "Paluch"
            };

            _artistsDictionary.Add(artist3.Id, artist3);
        }
    }
}

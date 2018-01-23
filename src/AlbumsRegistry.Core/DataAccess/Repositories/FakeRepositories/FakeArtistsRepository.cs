using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlbumsRegistry.Core.Models;
using Newtonsoft.Json;

namespace AlbumsRegistry.Core.DataAccess.Repositories.FakeRepositories
{
    public class FakeArtistsRepository : IArtistsRepository
    {
        private Dictionary<int, Artist> _artistsDictionary;
        private int _nextId;
        private readonly string _artistsJsonFile = $"{AppDomain.CurrentDomain.BaseDirectory}\\artists.json";

        public FakeArtistsRepository()
        {
            // Seed();
            GetArtists();
        }

        public void CreateArtist(Artist artist)
        {
            artist.Id = ++_nextId;
            _artistsDictionary.Add(artist.Id, artist);
            SaveJsonFile();
        }

        public IEnumerable<Artist> GetArtists()
        {
            _artistsDictionary = new Dictionary<int, Artist>();

            if (File.Exists(_artistsJsonFile))
            {
                var json = File.ReadAllText(_artistsJsonFile);
                _artistsDictionary = JsonConvert.DeserializeObject<Dictionary<int, Artist>>(json);
                _nextId = _artistsDictionary.Max(k => k.Key) + 1;
            }

            return _artistsDictionary.Values;
        }

        public Artist GetArtistById(int id)
        {
            return _artistsDictionary.Keys.Contains(id) == false ? null : _artistsDictionary[id];
        }

        public void UpdateArtist(Artist artist)
        {
            _artistsDictionary.Remove(artist.Id);
            _artistsDictionary.Add(artist.Id, artist);
            SaveJsonFile();
        }

        // ReSharper disable once UnusedMember.Local
        private void Seed()
        {
            if (File.Exists(_artistsJsonFile))
            {
                File.Delete(_artistsJsonFile);
            }

            File.CreateText(_artistsJsonFile).Close();

            _artistsDictionary = new Dictionary<int, Artist>();

            var artist1 = new Artist
            {
                City = "Warszawa",
                Id = ++_nextId,
                Name = "Tede"
            };

            _artistsDictionary.Add(artist1.Id, artist1);

            var artist2 = new Artist
            {
                City = "Warszawa",
                Id = ++_nextId,
                Name = "Chada"
            };

            _artistsDictionary.Add(artist2.Id, artist2);

            var artist3 = new Artist
            {
                City = "Poznań",
                Id = ++_nextId,
                Name = "Paluch"
            };

            _artistsDictionary.Add(artist3.Id, artist3);
            SaveJsonFile();
        }

        private void SaveJsonFile()
        {
            var json = JsonConvert.SerializeObject(_artistsDictionary);
            File.WriteAllText(_artistsJsonFile, json);
        }
    }
}

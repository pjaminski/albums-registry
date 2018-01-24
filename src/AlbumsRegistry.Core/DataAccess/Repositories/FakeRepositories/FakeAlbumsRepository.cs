using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlbumsRegistry.Core.Models;
using Newtonsoft.Json;

namespace AlbumsRegistry.Core.DataAccess.Repositories.FakeRepositories
{
    public class FakeAlbumsRepository : IAlbumsRepository
    {
        private Dictionary<int, Album> _albumsDictionary;
        private int _nextId;
        private readonly string _albumJsonFile = $"{AppDomain.CurrentDomain.BaseDirectory}\\albums.json";

        public FakeAlbumsRepository()
        {
            //Seed();
            GetAlbums();
        }

        public void CreateAlbum(Album album)
        {
            album.Id = ++_nextId;
            _albumsDictionary.Add(album.Id, album);
            SaveJsonFile(); ;
        }

        public IEnumerable<Album> GetAlbums()
        {
            _albumsDictionary = new Dictionary<int, Album>();

            if (File.Exists(_albumJsonFile))
            {
                var json = File.ReadAllText(_albumJsonFile);
                _albumsDictionary = JsonConvert.DeserializeObject<Dictionary<int, Album>>(json);
                _nextId = _albumsDictionary.Max(k => k.Key) + 1;
            }

            return _albumsDictionary.Values;
        }

        public Album GetAlbumById(int id)
        {
            return _albumsDictionary.Keys.Contains(id) == false ? null : _albumsDictionary[id];
        }

        public void UpdateAlbum(Album album)
        {
            _albumsDictionary.Remove(album.Id);
            _albumsDictionary.Add(album.Id, album);
            SaveJsonFile();
        }

        private void Seed()
        {
            if (File.Exists(_albumJsonFile))
            {
                File.Delete(_albumJsonFile);
            }

            File.CreateText(_albumJsonFile).Close();

            _albumsDictionary = new Dictionary<int, Album>();

            var album1 = new Album
            {
                Artist = new Artist {City = "Warszawa", Id = 1, Name = "Tede"},
                ArtistId = 1,
                Id = ++_nextId,
                Publisher = new Publisher {City = "Warszawa", Id = 1, Name = "Wielkie Joł"},
                PublisherId = 1,
                ReleaseYear = 2004,
                Title = "Hajs Hajs Hajs",
                TracksCount = 22
            };

            _albumsDictionary.Add(album1.Id, album1);

            var album2 = new Album
            {
                Artist = new Artist { City = "Poznań", Id = 3, Name = "Paluch" },
                ArtistId = 3,
                Id = ++_nextId,
                Publisher = new Publisher { City = "Warszawa", Id = 3, Name = "Wielkie Joł" },
                PublisherId = 3,
                ReleaseYear = 2017,
                Title = "Złota owca",
                TracksCount = 14
            };

            _albumsDictionary.Add(album2.Id, album2);

            var album3 = new Album
            {
                Artist = new Artist { City = "Warszawa", Id = 1, Name = "Tede" },
                ArtistId = 1,
                Id = ++_nextId,
                Publisher = new Publisher { City = "Opole", Id = 2, Name = "Step Records" },
                PublisherId = 2,
                Title = "Album3",
                TracksCount = 22
            };

            _albumsDictionary.Add(album3.Id, album3);

            var album4 = new Album
            {
                Artist = new Artist { City = "Warszawa", Id = 3, Name = "Vienio & Pele" },
                ArtistId = 3,
                Id = ++_nextId,
                Publisher = new Publisher { City = "Warszawa", Id = 1, Name = "Alkopoligamia" },
                PublisherId = 1,
                ReleaseYear = 2013,
                Title = "Autentyk 2",
            };

            _albumsDictionary.Add(album4.Id, album4);
            SaveJsonFile();
        }

        private void SaveJsonFile()
        {
            var json = JsonConvert.SerializeObject(_albumsDictionary);
            File.WriteAllText(_albumJsonFile, json);
        }
    }
}

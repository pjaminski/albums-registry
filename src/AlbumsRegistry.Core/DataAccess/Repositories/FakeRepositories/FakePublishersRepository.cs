using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlbumsRegistry.Core.Models;
using Newtonsoft.Json;

namespace AlbumsRegistry.Core.DataAccess.Repositories.FakeRepositories
{
    public class FakePublishersRepository : IPublishersRepository
    {
        private Dictionary<int, Publisher> _publishersDictionary;
        private int _nextId;
        private readonly string _publishersJsonFile = $"{AppDomain.CurrentDomain.BaseDirectory}\\publishers.json";

        public FakePublishersRepository()
        {
            //Seed();
            GetPublishers();
        }

        public void CreatePublisher(Publisher publisher)
        {
            publisher.Id = ++_nextId;
            _publishersDictionary.Add(publisher.Id, publisher);
            SaveJsonFile();
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            _publishersDictionary = new Dictionary<int, Publisher>();

            if (File.Exists(_publishersJsonFile))
            {
                var json = File.ReadAllText(_publishersJsonFile);
                _publishersDictionary = JsonConvert.DeserializeObject<Dictionary<int, Publisher>>(json);
                _nextId = _publishersDictionary.Max(k => k.Key) + 1;
            }

            return _publishersDictionary.Values;
        }

        public Publisher GetPublisherById(int id)
        {
            return _publishersDictionary.Keys.Contains(id) == false ? null : _publishersDictionary[id]; ;
        }

        public void UpdatePublisher(Publisher publisher)
        {
            _publishersDictionary.Remove(publisher.Id);
            _publishersDictionary.Add(publisher.Id, publisher);
            SaveJsonFile();
        }

        private void Seed()
        {
            if (File.Exists(_publishersJsonFile))
            {
                File.Delete(_publishersJsonFile);
            }

            File.CreateText(_publishersJsonFile).Close();

            _publishersDictionary = new Dictionary<int, Publisher>();

            var publisher1 = new Publisher
            {
                City = "Warszawa",
                Id = ++_nextId,
                Name = "Alkopoligamia"
            };

            _publishersDictionary.Add(publisher1.Id, publisher1);

            var publisher2 = new Publisher
            {
                City = "Opole",
                Id = ++_nextId,
                Name = "Step Records"
            };

            _publishersDictionary.Add(publisher2.Id, publisher2);

            var publisher3 = new Publisher
            {
                City = "Warszawa",
                Id = ++_nextId,
                Name = "Wielkie Joł"
            };

            _publishersDictionary.Add(publisher3.Id, publisher3);
            SaveJsonFile();
        }
        private void SaveJsonFile()
        {
            var json = JsonConvert.SerializeObject(_publishersDictionary);
            File.WriteAllText(_publishersJsonFile, json);
        }
    }
}

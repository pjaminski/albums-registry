using System;
using System.Collections.Generic;
using AlbumsRegistry.Repository.Models;

namespace AlbumsRegistry.Repository.Repositories.FakeRepositories
{
    public class FakePublisherRepository : IPublisherRepository
    {
        private Dictionary<int, Publisher>_publishersDictionary;

        public FakePublisherRepository()
        {
            Seed();
        }

        public bool CreatePublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            return _publishersDictionary.Values;
        }

        public Publisher GetPublisherById(int id)
        {
            return _publishersDictionary[id];
        }

        public Publisher UpdatePublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        private void Seed()
        {
            _publishersDictionary = new Dictionary<int, Publisher>();

            var publisher1 = new Publisher
            {
                City = "Warszawa",
                Id = 1,
                Name = "Alkopoligamia"
            };

            _publishersDictionary.Add(publisher1.Id, publisher1);

            var publisher2 = new Publisher
            {
                City = "Opole",
                Id = 2,
                Name = "Step Records"
            };

            _publishersDictionary.Add(publisher2.Id, publisher2);

            var publisher3 = new Publisher
            {
                City = "Warszawa",
                Id = 3,
                Name = "Wielkie Joł"
            };

            _publishersDictionary.Add(publisher3.Id, publisher3);
        }
    }
}

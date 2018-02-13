using System.Collections.Generic;
using System.Linq;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.DataAccess.Repositories
{
    public class PublishersRepository : IPublishersRepository
    {
        private readonly AlbumsRegistryDbContext _dbContext;

        public PublishersRepository()
        {
            _dbContext = new AlbumsRegistryDbContext();
        }

        public void CreatePublisher(Publisher publisher)
        {
            _dbContext.Publishers.Add(publisher);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            return _dbContext.Publishers.OrderBy(p => p.Name).ToList();
        }

        public Publisher GetPublisherById(int id)
        {
            return _dbContext.Publishers.SingleOrDefault(p => p.Id == id);
        }

        public void UpdatePublisher(Publisher publisher)
        {
            var publisherBeforeChanges = GetPublisherById(publisher.Id);

            if (publisherBeforeChanges != null)
            {
                publisherBeforeChanges.Name = publisher.Name;
                publisherBeforeChanges.City = publisher.City;
                _dbContext.SaveChanges();
            }
        }
    }
}

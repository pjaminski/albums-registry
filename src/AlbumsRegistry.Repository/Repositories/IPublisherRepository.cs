using System.Collections.Generic;
using AlbumsRegistry.Repository.Models;

namespace AlbumsRegistry.Repository.Repositories
{
    public interface IPublisherRepository
    {
        bool CreatePublisher(Publisher publisher);

        IEnumerable<Publisher> GetPublishers();

        Publisher GetPublisherById(int id);

        Publisher UpdatePublisher(Publisher publisher);
    }
}

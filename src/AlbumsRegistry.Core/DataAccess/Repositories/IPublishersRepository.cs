using System.Collections.Generic;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.DataAccess.Repositories
{
    public interface IPublishersRepository
    {
        bool CreatePublisher(Publisher publisher);

        IEnumerable<Publisher> GetPublishers();

        Publisher GetPublisherById(int id);

        Publisher UpdatePublisher(Publisher publisher);
    }
}

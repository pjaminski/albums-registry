using System.Collections.Generic;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.DataAccess.Repositories
{
    public interface IPublishersRepository
    {
        void CreatePublisher(Publisher publisher);

        IEnumerable<Publisher> GetPublishers();

        Publisher GetPublisherById(int id);

        void UpdatePublisher(Publisher publisher);
    }
}

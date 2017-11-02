using System.Collections.Generic;
using AlbumsRegistry.Model;

namespace AlbumsRegistry.WebApi.DataAccess.Repositories
{
    public interface IPublisherRepository
    {
        bool CreatePublisher(Publisher publisher);

        IEnumerable<Publisher> GetPublishers();

        Publisher GetPublisherById(int id);

        Publisher UpdatePublisher(Publisher publisher);
    }
}

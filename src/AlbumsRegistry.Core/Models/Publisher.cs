using System.ComponentModel.DataAnnotations;

namespace AlbumsRegistry.Core.Models
{
    public class Publisher : INameCityModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }
    }
}

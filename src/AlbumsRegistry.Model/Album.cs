using System.ComponentModel.DataAnnotations;

namespace AlbumsRegistry.Model
{
    public class Album
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public int? ReleaseYear { get; set; }

        [Required]
        public Artist Artist { get; set; }

        public Publisher Publisher { get; set; }

        public int? TracksCount { get; set; }
    }
}

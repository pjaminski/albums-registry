using System.ComponentModel.DataAnnotations;

namespace AlbumsRegistry.Core.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Strings),
            ErrorMessageResourceName = "General_Validation_ValueIsRequired")]
        [StringLength(255,
            ErrorMessageResourceType = typeof(Strings),
            ErrorMessageResourceName = "General_Validation_ValueIsLimited")]
        public string Title { get; set; }

        [Range(0, int.MaxValue,
            ErrorMessageResourceType = typeof(Strings),
            ErrorMessageResourceName = "General_Validation_MinValue")]
        public int? ReleaseYear { get; set; }

        public virtual Artist Artist { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Strings),
            ErrorMessageResourceName = "General_Validation_ValueIsRequired")]
        public int ArtistId { get; set; }

        public virtual Publisher Publisher { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Strings),
            ErrorMessageResourceName = "General_Validation_ValueIsRequired")]
        public int PublisherId { get; set; }
    }
}

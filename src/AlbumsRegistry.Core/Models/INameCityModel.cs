using System.ComponentModel.DataAnnotations;

namespace AlbumsRegistry.Core.Models
{
    public interface INameCityModel
    {
        int Id { get; set; }

        [Required(AllowEmptyStrings = false, 
            ErrorMessageResourceType = typeof(Strings), 
            ErrorMessageResourceName = "General_Validation_ValueIsRequired")]
        [StringLength(255,
            ErrorMessageResourceType = typeof(Strings),
            ErrorMessageResourceName = "General_Validation_ValueIsLimited")]
        string Name { get; set; }

        [StringLength(255,
            ErrorMessageResourceType = typeof(Strings),
            ErrorMessageResourceName = "General_Validation_ValueIsLimited")]
        string City { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace AlbumsRegistry.Core.ViewModels
{
    public class ActivationAdminModeViewModel
    {
        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Strings),
            ErrorMessageResourceName = "General_Validation_ValueIsRequired")]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
    }
}
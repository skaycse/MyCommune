using System.ComponentModel.DataAnnotations;

namespace MyCommune.Models.ViewModel.Account
{
    public class ChangePassword
    {
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}

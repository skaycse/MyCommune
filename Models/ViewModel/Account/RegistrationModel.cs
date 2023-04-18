namespace MyCommune.Models.ViewModel.Account
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegistrationModel
    {

        [Required]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Phone]
        public string Mobile { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}

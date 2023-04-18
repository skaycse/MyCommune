using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyCommune.Models.ViewModel.User
{
    public class UserDetailViewModel
    {
        public Guid Id { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public long Mobile { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [HiddenInput]
        public int UserDetailId { get; set; }
    }

}

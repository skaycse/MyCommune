using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCommune.DataModels.Users
{
    [Table("users")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(12), DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [Column(TypeName = "Date"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "Date")]
        public DateTime ModifiedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }

        [MaxLength(100)]
        public string PasswordResetToken { get; set; }
        public DateTime? PasswordResetTokenExpiry { get; set; }

        public UserDetail UserDetails { get; set; }


    }

    [Table("user_details")]
    public class UserDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]    
        public string LastName { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public override string ToString()
        {
            return FirstName + LastName;
        }

    }
}

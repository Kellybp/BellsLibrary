using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BellsLibrary.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public required string AccountType { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "First Name cannot be longer than 100 characters")]
        public required string FirstName { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Last Name cannot be longer than 100 characters")]
        public required string LastName { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Username cannot be longer than 100 characters")]
        public required string UserName { get; set; }

        [Required]
        [MaxLength(225, ErrorMessage = "Password cannot be longer than 255 characters")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        public ICollection<Loan>? Loans { get; set; }
    }
}

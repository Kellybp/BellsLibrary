using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BellsLibrary.Data.Models.User;

namespace BellsLibrary.Data.Models
{
    public class Loan : BaseModel
    {
        [Required]
        public required Guid BookId { get; set; }

        [ForeignKey("BookId")]
        public required Book Book { get; set; }

        [Required]
        public required Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public required ApplicationUser User { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public required DateTime LoanDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ReturnedDate { get; set; }
    }
}

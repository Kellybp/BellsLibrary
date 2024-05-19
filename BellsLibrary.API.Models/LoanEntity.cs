using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BellsLibrary.API.Models;

namespace BellsLibrary.API.Services.Models
{
    public class LoanEntity : BaseModel
    {
        [Required]
        public  Guid BookId { get; set; }

        [ForeignKey("BookId")]
        public  BookEntity Book { get; set; }

        //[Required]
        //public  int AccountId { get; set; }

        //[ForeignKey("AccountId")]
        //public  Account Account { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public  DateTime LoanDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ReturnedDate { get; set; }
    }
}

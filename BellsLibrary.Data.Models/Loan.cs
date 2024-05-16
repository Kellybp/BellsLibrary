﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BellsLibrary.Data.Models
{
    public class Loan : BaseModel
    {
        [Required]
        public required Guid BookId { get; set; }

        [ForeignKey("BookId")]
        public required Book Book { get; set; }

        //[Required]
        //public required int AccountId { get; set; }

        //[ForeignKey("AccountId")]
        //public required Account Account { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public required DateTime LoanDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ReturnedDate { get; set; }
    }
}
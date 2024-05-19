using BellsLibrary.API.Models;
using System.ComponentModel.DataAnnotations;

namespace BellsLibrary.API.Services.Models
{
    public class BookEntity : BaseModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "First Name cannot be longer than 100 characters")]
        public required string Title { get; set; }

        [Required]
        public  string Description { get; set; }

        [Required]
        public  byte[] CoverImage { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public  DateTime PublicationDate { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "First Name cannot be longer than 255 characters")]
        public  string Publisher { get; set; }

        [Required]
        [MaxLength(13, ErrorMessage = "First Name cannot be longer than 13 characters")]
        public  string ISBN { get; set; }

        [Required]
        public  int PgCount { get; set; }

        [Required]
        public  string Category { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "First Name cannot be longer than 100 characters")]
        public  string Author { get; set; }

        public bool IsFeatured { get; set; }
    }
}

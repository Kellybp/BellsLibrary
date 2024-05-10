using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace BellsLibrary.Models
{
    public class Book
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "First Name cannot be longer than 100 characters")]
        public required string Title { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public required byte[] CoverImage { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public required DateTime PublicationDate { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "First Name cannot be longer than 255 characters")]
        public required string Publisher { get; set; }

        [Required]
        [MaxLength(13, ErrorMessage = "First Name cannot be longer than 13 characters")]
        public required string ISBN { get; set; }

        [Required]
        public required int PgCount { get; set; }

        [Required]
        public required string Category { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "First Name cannot be longer than 100 characters")]
        public required string Author { get; set; }

    }
}

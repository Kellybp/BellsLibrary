using System.ComponentModel.DataAnnotations;

namespace BellsLibrary.Data.Models
{
    public abstract class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Modified { get; set; }
    }
}

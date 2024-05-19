using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BellsLibrary.Data.Models.User
{
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        //[Key]
        //[Required]
        //public override required Guid UserId { get; set; }

        //[ForeignKey("UserId")]
        //public required ApplicationUser User { get; set; }
        //[Required]
        //public override required Guid RoleId { get; set; }

        //[ForeignKey("RoleId")]
        //public required ApplicationRole Role { get; set; }
    }
}

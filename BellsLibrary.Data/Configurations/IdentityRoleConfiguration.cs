using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BellsLibrary.Data.Models.User;

namespace BellsLibrary.Data.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            //Generate Identity Roles
            builder.HasData(new List<ApplicationRole>
            {
                new  ApplicationRole{
                    Id = new Guid("1c5e174e-3b0e-446f-86af-483d56fd7210"),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR".ToUpper()
                },
                new  ApplicationRole{
                   Id = new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                   Name = "Librarian",
                   NormalizedName = "LIBRARIAN".ToUpper()
                },
                new  ApplicationRole{
                    Id = new Guid("3c5e174e-3b0e-446f-86af-483d56fd7210"),
                    Name = "Customer",
                    NormalizedName = "CUSTOMER".ToUpper()
                }
            });
        }
    }
}

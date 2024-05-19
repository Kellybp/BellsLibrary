using BLM = BellsLibrary.Data.Models;
using BellsLibrary.Data.Models;
using Microsoft.EntityFrameworkCore;
using BellsLibrary.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BellsLibrary.Data.Models.User;
using Microsoft.AspNetCore.Identity;

namespace BellsLibrary.Data
{
    public class BellsLibraryContext : IdentityDbContext<ApplicationUser, 
        IdentityRole<Guid>, Guid, IdentityUserClaim<Guid>,
        ApplicationUserRole,
        IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>,
        IdentityUserToken<Guid>>
    {
        public DbSet<BLM.Book> Books { get; set; }
        public DbSet<BLM.Loan> Loans { get; set; }

        public BellsLibraryContext(DbContextOptions<BellsLibraryContext> options) : base(options) { }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            new IdentityRoleConfiguration().Configure(modelBuilder.Entity<ApplicationRole>());

            new BookEntityConfiguration().Configure(modelBuilder.Entity<Book>());
            new LoanEntityConfiguration().Configure(modelBuilder.Entity<Loan>());
         
            base.OnModelCreating(modelBuilder);
        }
    }
}

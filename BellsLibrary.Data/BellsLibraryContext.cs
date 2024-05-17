using BLM = BellsLibrary.Data.Models;
using BellsLibrary.Data.Models;
using Microsoft.EntityFrameworkCore;
using BellsLibrary.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BellsLibrary.Data
{
    public class BellsLibraryContext : IdentityDbContext
    {
        public DbSet<BLM.Book> Books { get; set; }
        public DbSet<BLM.Loan> Loans { get; set; }

        public BellsLibraryContext(DbContextOptions<BellsLibraryContext> options) : base(options) { }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new BookEntityConfiguration().Configure(modelBuilder.Entity<Book>());
            new LoanEntityConfiguration().Configure(modelBuilder.Entity<Loan>());
        }
    }
}

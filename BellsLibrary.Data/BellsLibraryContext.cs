using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Principal;

namespace BellsLibrary.Data
{
    public class BellsLibraryContext : DbContext
    {
        int numberOfEntities = 20;

        ILogger<LibraryContext> _logger;
        private readonly DataSeeder _dataSeeder;

        public LibraryContext(DbContextOptions options,
            ILogger<LibraryContext> logger,
            DataSeeder dataseeders) : base(options)
        {
            _logger = logger;
            _dataSeeder = dataseeders;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book)
                .WithMany()
                .HasForeignKey(l => l.BookId);
        }
}

using Microsoft.Extensions.Logging;
using BLM = BellsLibrary.Data.Models;
using BellsLibrary.Data.Initializer;
using BellsLibrary.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BellsLibrary.Data
{
    public class BellsLibraryContext : DbContext
    {
        int numberOfEntities = 20;

        ILogger<BellsLibraryContext> _logger;
        private readonly DataSeeder _dataSeeder;

        public BellsLibraryContext(DbContextOptions options,
            ILogger<BellsLibraryContext> logger,
            DataSeeder dataseeders) : base(options)
        {
            _logger = logger;
            _dataSeeder = dataseeders;
        }

        public DbSet<BLM.Book> Books { get; set; }
        public DbSet<BLM.Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BLM.Loan>()
                .HasOne(l => l.Book)
                .WithMany()
                .HasForeignKey(l => l.BookId);


            var books = _dataSeeder.GetBookGenerator().Generate(numberOfEntities);

            modelBuilder.Entity<Book>()
               .HasData(books);

            var loans = _dataSeeder.GetLoanGenerator(books).Generate(numberOfEntities);

            modelBuilder.Entity<Loan>()
                .HasData(loans);
        }
    }
}

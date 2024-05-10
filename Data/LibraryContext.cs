using BellsLibrary.Models;
using BellsLibrary.Services;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace BellsLibrary.Data
{
    public class LibraryContext : DbContext
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

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Account)
                .WithMany(a => a.Loans)
                .HasForeignKey(l => l.AccountId);



            var books = _dataSeeder.GetBookGenerator().Generate(numberOfEntities);

            modelBuilder.Entity<Book>()
               .HasData(books);

            var accounts = _dataSeeder.GetAccountGenerator().Generate(numberOfEntities);

            modelBuilder.Entity<Account>()
               .HasData(accounts);

            var loans = _dataSeeder.GetLoanGenerator(numberOfEntities+1, numberOfEntities*2).Generate(numberOfEntities);

            modelBuilder.Entity<Loan>()
                .HasData(loans);
        }
    }
}

using BellsLibrary.Data;
using BellsLibrary.Models;
using Bogus;
using System;
using static System.Reflection.Metadata.BlobBuilder;

namespace BellsLibrary.Services
{
    public class DataSeeder
    {
        Faker<Book>? _bookFaker = null;
        Faker<Account>? _accountFaker = null;
        Faker<Loan>? _loanFaker = null;

        public string[] categories = new string[] {
                "Action/Adventure fiction",
                "Children’s fiction",
                "Classic fiction",
                "Contemporary fiction",
                "Fantasy",
                "Graphic novel",
                "Historical fiction",
                "Horror",
                "LGBTQ+",
                "Literary fiction",
                "Mystery",
                "New adult",
                "Romance",
                "Satire",
                "Science fiction",
                "Short story",
                "Thriller",
                "Western",
                "Women’s fiction",
                "Young adult",
                "Art & photography",
                "Autobiography/Memoir",
                "Biography",
                "Essays",
                "Food & drink",
                "History",
                "How-To/Guides",
                "Humanities & social sciences",
                "Humor",
                "Parenting",
                "Philosophy",
                "Religion & spirituality",
                "Science & technology",
                "Self-help",
                "Travel",
                "True crime"};

        public string[] types = new string[]
        {
                "librarian",
                "customer",
                "admin"
        };

        public Faker<Book> GetBookGenerator()
        {
            if (_bookFaker is null)
            {
                int id = 0;
                _bookFaker = new Faker<Book>()
                    .RuleFor(b => b.ID, f => ++id)
                    .RuleFor(b => b.Title, f => f.Lorem.Sentence(3))
                    .RuleFor(b => b.Description, f => f.Lorem.Paragraph())
                    .RuleFor(b => b.PublicationDate, f => f.Date.Past(10))
                    .RuleFor(b => b.Publisher, f => f.Company.CompanyName())
                    .RuleFor(b => b.ISBN, f => f.Commerce.Ean13())
                    .RuleFor(b => b.PgCount, f => f.Random.Int(100, 1000))
                    .RuleFor(b => b.Category, f => f.PickRandom(categories))
                    .RuleFor(b => b.Author, f => f.Name.FullName())
                    .RuleFor(b => b.CoverImage, f => f.Random.Bytes(142));
            }

            return _bookFaker;
        }

        public Faker<Account> GetAccountGenerator()
        {
            if (_accountFaker is null)
            {
                int id = 0;
                _accountFaker = new Faker<Account>()
                    .RuleFor(b => b.ID, f => ++id)
                    .RuleFor(b => b.FirstName, f => f.Name.FirstName())
                    .RuleFor(b => b.LastName, f => f.Name.LastName())
                    .RuleFor(b => b.UserName, f => f.Internet.UserName())
                    .RuleFor(b => b.Password, f => f.Lorem.Sentence(3))
                    .RuleFor(b => b.AccountType, f => f.PickRandom(types));
            }

            return _accountFaker;
        }

        public Faker<Loan> GetLoanGenerator(int firstID, int lastID)
        {
            if (_loanFaker is null)
            {
                int id = 0;
                _loanFaker = new Faker<Loan>()
                    .RuleFor(b => b.ID, f => ++id)
                    .RuleFor(l => l.BookId, f => f.Random.Number(firstID, lastID))
                    .RuleFor(l => l.AccountId, f => f.Random.Number(firstID, lastID))
                    .RuleFor(l => l.LoanDate, f => f.Date.Recent(30))
                    .RuleFor(l => l.ReturnedDate, f => f.Random.Bool(0.5f) ? null : f.Date.Recent(30));
            }

            return _loanFaker;
        }
    }
}

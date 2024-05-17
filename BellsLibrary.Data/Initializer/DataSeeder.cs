using BellsLibrary.Data.Models;
using Bogus;

namespace BellsLibrary.Data.Initializer
{
    public class DataSeeder
    {
        Faker<Book>? _bookFaker = null;
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

        public Faker<Book> GetBookGenerator()
        {
            if (_bookFaker is null)
            {
                _bookFaker = new Faker<Book>()
                    .RuleFor(b => b.Id, f => Guid.NewGuid())
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

        public Faker<Loan> GetLoanGenerator(List<Book> books)
        {

            Guid[] bookIds = new Guid[books.Count];

            for (int x = 0; x < books.Count; x++)
            {
                bookIds[x] = books[x].Id;
            }

            if (_loanFaker is null)
            {
                _loanFaker = new Faker<Loan>()
                    .RuleFor(b => b.Id, f => Guid.NewGuid())
                    .RuleFor(b => b.BookId, f => f.PickRandom(bookIds))
                    .RuleFor(b => b.LoanDate, f => f.Date.Recent(30))
                    .RuleFor(b => b.ReturnedDate, f => f.Random.Bool(0.5f) ? null : f.Date.Recent(30));
            }

            return _loanFaker;
        }
    }
}

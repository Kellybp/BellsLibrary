using BellsLibrary.Data.Models;
using BellsLibrary.Data.Models.User;
using Bogus;
using Microsoft.AspNetCore.Identity;
using static System.Reflection.Metadata.BlobBuilder;

namespace BellsLibrary.Data.Initializer
{
    public class DataSeeder
    {
        Faker<Book>? _bookFaker = null;
        Faker<Loan>? _loanFaker = null;
        Faker<ApplicationUser>? _identityUserFaker = null;
        Faker<ApplicationUserRole>? _identityUserRoleFaker = null;

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
                    .RuleFor(b => b.CoverImage, f => ConvertToBytes(f.Image.PicsumUrl()));
            }

            return _bookFaker;
        }

        public Faker<Loan> GetLoanGenerator(List<Book> books, List<ApplicationUser> users)
        {
            if(_loanFaker is null)
            {
                Guid[] bookIds = new Guid[books.Count];
                Guid[] userIds = new Guid[users.Count];

                for (int x = 0; x < books.Count; x++)
                {
                    bookIds[x] = books[x].Id;
                }

                for (int x = 0; x < users.Count; x++)
                {
                    userIds[x] = users[x].Id;
                }

                if (_loanFaker is null)
                {
                    _loanFaker = new Faker<Loan>()
                        .RuleFor(b => b.Id, f => Guid.NewGuid())
                        .RuleFor(b => b.BookId, f => f.PickRandom(bookIds))
                        .RuleFor(b => b.LoanDate, f => f.Date.Recent(30))
                        .RuleFor(b => b.UserId, f => f.PickRandom(userIds))
                        .RuleFor(b => b.ReturnedDate, f => f.Random.Bool(0.5f) ? null : f.Date.Recent(30));
                }
            }
            return _loanFaker;
        }

        public Faker<ApplicationUser> GetUserGenerator()
        {
            //Default Password
            var hasher = new PasswordHasher<ApplicationUser>();
            string password = hasher.HashPassword(null, "Pa$$w0rd");

            _identityUserFaker = new Faker<ApplicationUser>()
                 .RuleFor(u => u.Id, f => Guid.NewGuid())
                 .RuleFor(u => u.UserName, f => f.Internet.UserName())
                 .RuleFor(u => u.Email, f => f.Internet.Email())
                 .RuleFor(u => u.PasswordHash, f => password)
                 .RuleFor(u => u.EmailConfirmed, f => true);

            

            return _identityUserFaker.UseSeed(125);
        }

        public Faker<ApplicationUserRole> GetUserRoleGenerator(List<ApplicationUser> users)
        {
            Guid[] roles = new Guid[]
            {
                new Guid("1c5e174e-3b0e-446f-86af-483d56fd7210"),
                new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                new Guid("3c5e174e-3b0e-446f-86af-483d56fd7210")
            };

            Guid[] userIds = new Guid[users.Count];

            for (int x = 0; x < users.Count; x++)
            {
                userIds[x] = users[x].Id;
            }
            
            _identityUserRoleFaker = new Faker<ApplicationUserRole>()
                .RuleFor(u => u.RoleId, f => f.PickRandom(roles))
                .RuleFor(u => u.UserId, f => f.PickRandom(userIds));

            return _identityUserRoleFaker;
        }

        private byte[] ConvertToBytes(string filePath)
        {
            try
            {
                byte[] fileBytes = File.ReadAllBytes(filePath);
                return fileBytes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BellsLibrary.Data;
using BellsLibrary.Models;

namespace BellsLibrary.Views.Books
{
    public class IndexModel : PageModel
    {
        private readonly BellsLibrary.Data.LibraryContext _context;

        public IndexModel(BellsLibrary.Data.LibraryContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Books.ToListAsync();
        }
    }
}

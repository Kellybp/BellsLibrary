using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BellsLibrary.Models;
using BellsLibrary.Data;

namespace BellsLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, LibraryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            Task<ActionResult<Book>> book = new BookController(_context).GetBookById(23);
            try
            {
                book.Wait();
            }catch (Exception ex) { }
            if (book.IsCompletedSuccessfully)
            {
                Book displayBook = book.Result.Value;
                return View(displayBook);
            }
            else
            {
            return View();
            }

            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}

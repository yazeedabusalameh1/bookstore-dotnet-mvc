using Microsoft.AspNetCore.Mvc;
using ProjectForTraining.Models;
using ProjectForTraining.Models.Repositories;

namespace ProjectForTraining.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookstoreRepository<Book> bookRepository;
        private readonly IBookstoreRepository<Author> authorRepository;

        public HomeController(IBookstoreRepository<Book> bookRepository, IBookstoreRepository<Author> authorRepository)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
        }

        public IActionResult Index()
        {
            ViewBag.TotalBooks = bookRepository.List().Count;
            ViewBag.TotalAuthors = authorRepository.List().Count;
            return View();
        }
    }
}



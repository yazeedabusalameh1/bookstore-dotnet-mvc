using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectForTraining.Models;
using ProjectForTraining.Models.Repositories;
using ProjectForTraining.ViewModel;

namespace ProjectForTraining.Controllers
{
    public class BookController1 : Controller
    {
        private readonly IBookstoreRepository<Book> bookRepository;
        private readonly IBookstoreRepository<Author> authorRepository;

        public BookController1(IBookstoreRepository<Book> bookRepository, IBookstoreRepository<Author> authorRepository)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
        }
        // GET: BookController1
        public ActionResult Index()
        {
            var books = bookRepository.List();
            return View("~/Views/Book/Index.cshtml", books);
        }

        // GET: BookController1/Details/5
        public ActionResult Details(int id)
        {
            var book = bookRepository.Find(id);
            if (book == null) return NotFound();
            return View("~/Views/Book/Details.cshtml", book);
        }

        // GET: BookController1/Create
        public ActionResult Create()
        {
            var model = new BookAuthorViewModel
            {
                Authors = FillSelectList()
            };
            return View("~/Views/Book/Create.cshtml", model);
        }

        // POST: BookController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModel model)
        {
            if (!model.AuthorId.HasValue || model.AuthorId.Value <= 0)
            {
                ViewBag.Message = "Please select an author from the list";
                var vmodel = new BookAuthorViewModel
                {
                    Authors = FillSelectList()
                };
                return View("~/Views/Book/Create.cshtml", vmodel);
            }

            if (!ModelState.IsValid)
            {
                model.Authors = authorRepository.List().ToList();
                return View("~/Views/Book/Create.cshtml", model);
            }

            var author = authorRepository.Find(model.AuthorId.Value);
            var book = new Book
            {
                Id = model.BookId ?? 0,
                Title = model.Title ?? "",
                Description = model.Description ?? "",
                AuthorId = model.AuthorId.Value,
                Author = author
            };
            bookRepository.Add(book);
            return RedirectToAction(nameof(Index));
        }

        // GET: BookController1/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookRepository.Find(id);
            if (book == null) return NotFound();
            var viewModel = new BookAuthorViewModel
            {
                BookId = book.Id,
                Title = book.Title,
                Description = book.Description,
                AuthorId = book.AuthorId,
                Authors = authorRepository.List().ToList()
            };
            return View("~/Views/Book/Edit.cshtml", viewModel);
        }

        // POST: BookController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookAuthorViewModel viewModel)
        {
            if (!viewModel.AuthorId.HasValue || viewModel.AuthorId.Value <= 0)
            {
                ViewBag.Message = "Please select an author from the list";
                viewModel.Authors = authorRepository.List().ToList();
                return View("~/Views/Book/Edit.cshtml", viewModel);
            }

            var author = authorRepository.Find(viewModel.AuthorId.Value);
            var updated = new Book
            {
                Id = viewModel.BookId ?? 0,
                Title = viewModel.Title ?? "",
                Description = viewModel.Description ?? "",
                AuthorId = viewModel.AuthorId.Value,
                Author = author
            };
            bookRepository.Update(id, updated);
            return RedirectToAction(nameof(Index));
        }

        // GET: BookController1/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookRepository.Find(id);
            if (book == null) return NotFound();
            return View("~/Views/Book/Delete.cshtml", book);
        }

        // POST: BookController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            bookRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        List<Author> FillSelectList()
        {
            var authors = authorRepository.List().ToList();
            authors.Insert(0, new Author { Id = 0, FullName = "--- Please Select an Author ---" });
            return authors;
        }

    }
}

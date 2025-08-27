using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectForTraining.Models;
using ProjectForTraining.Models.Repositories;

namespace ProjectForTraining.Controllers
{
    public class authorController : Controller
    {
        private readonly IBookstoreRepository<Author> authorRepository;

        public authorController(IBookstoreRepository<Author> authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        // GET: authorController
        public ActionResult Index()
        {
            var authors = authorRepository.List();
            return View(authors);
        }

        // GET: authorController/Details/5
        public ActionResult Details(int id)
        {
            var author = authorRepository.Find(id);
            return View(author);
        }

        // GET: authorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: authorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            try
            {
                authorRepository.Add(author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: authorController/Edit/5
        public ActionResult Edit(int id)
        {
            var author = authorRepository.Find(id);
            return View(author);
        }

        // POST: authorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Author author)
        {
            try
            {
                authorRepository.Update(id, author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: authorController/Delete/5
        public ActionResult Delete(int id)
        {
            var author = authorRepository.Find(id);
            return View(author);
        }

        // POST: authorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Author author)
        {
            try
            {
                authorRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

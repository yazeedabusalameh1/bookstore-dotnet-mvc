using ProjectForTraining.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectForTraining.Models.Repositories
{
    public class BookRepository : IBookstoreRepository<Book>
    {
        private readonly BookStoreDbContext _context;

        public BookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Add(Book entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public Book Find(int id)
        {
            return _context.Books
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == id);
        }

        public IList<Book> List()
        {
            return _context.Books
                .Include(b => b.Author)
                .ToList();
        }

        public List<Book> Search(string item)
        {
            return _context.Books.Where(a => a.Title.Contains(item)).ToList();

        }

        public void Update(int id, Book newBook)
        {
            var book = Find(id);
            if (book != null)
            {
                book.Title = newBook.Title;
                book.Description = newBook.Description;
                book.AuthorId = newBook.AuthorId;
                book.Author = newBook.Author;
                _context.SaveChanges();
            }
        }
    }
}

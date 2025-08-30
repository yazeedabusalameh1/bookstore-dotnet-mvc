using Microsoft.EntityFrameworkCore;

namespace ProjectForTraining.Models.Repositories
{
    public class BookDbRepositiory : IBookstoreRepository<Book>
    {
        private readonly BookStoreDbContext _context;

        public BookDbRepositiory(BookStoreDbContext context)
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

        public void Update(int id, Book newBook)
        {
            _context.Update(newBook);
            _context.SaveChanges();
        
            
        }
    }
}

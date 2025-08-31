using ProjectForTraining.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectForTraining.Models.Repositories
{
    public class AuthorRepository : IBookstoreRepository<Author>
    {
        private readonly BookStoreDbContext _context;

        public AuthorRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Add(Author entity)
        {
            _context.Authors.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var author = Find(Id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }

        public Author Find(int Id)
        {
            return _context.Authors.Find(Id);
        }

        public IList<Author> List()
        {
            return _context.Authors.ToList();
        }

        public List<Author> Search(string item)
        {
            return _context.Authors.Where(a=>a.FullName.Contains(item)).ToList();
        }

        public void Update(int Id, Author newAuthor)
        {
            var author = Find(Id);
            if (author != null)
            {
                author.FullName = newAuthor.FullName;
                _context.SaveChanges();
            }
        }
    }
}

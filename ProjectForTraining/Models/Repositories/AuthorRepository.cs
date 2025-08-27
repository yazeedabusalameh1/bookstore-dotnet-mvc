
namespace ProjectForTraining.Models.Repositories
{
    public class AuthorRepository : IBookstoreRepository<Author>
    {
        IList<Author> authors;
        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author { Id = 1, FullName = "Yazeed Abusalameh" },
                new Author { Id = 2, FullName = "Ahmed Ali" },
                new Author { Id = 3, FullName = "Sara Mohammed" },
            };
        }
        public void Add(Author entity)
        {
            entity.Id = authors.Max(a=>a.Id) + 1;
            authors.Add(entity);
        }

        public void Delete(int Id)
        {
            var author = Find(Id);
            if (author != null)
                authors.Remove(author);
        }

        public Author Find(int Id)
        {
            var author = authors.SingleOrDefault(a => a.Id == Id);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public void Update(int Id, Author newAuthor)
        {
            var author = Find(Id);
            if (author != null)
                author.FullName = newAuthor.FullName;
        }
    }
}

using ProjectForTraining.Models;

namespace ProjectForTraining.ViewModel
{
    public class BookAuthorViewModel
    {
        public int BookId { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public List <Author> Authors { get; set; }
    }
}

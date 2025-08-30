using ProjectForTraining.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectForTraining.ViewModel
{
    public class BookAuthorViewModel
    {
        public int? BookId { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string? Title { get; set; }
        
        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }
        
        [Required(ErrorMessage = "Please select an author")]
        public int? AuthorId { get; set; }
        
        public List<Author>? Authors { get; set; }
    }
}

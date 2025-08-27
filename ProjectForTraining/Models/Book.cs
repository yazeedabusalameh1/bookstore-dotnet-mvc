using System.ComponentModel.DataAnnotations;

namespace ProjectForTraining.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }


        [Required]
        [StringLength(120,MinimumLength =5)]
        public string Description { get; set; }
        public Author Author { get; set; }
    }
}

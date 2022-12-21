using System.ComponentModel.DataAnnotations;

namespace WebLibraryApp.Models
{
    public class Authorship
    {
        [Key]
        public Guid WriterId { get; set; }
        public Writer? Writer { get; set; }

        [Key]
        public Guid BookId { get; set; }
        public Book? Book { get; set; }
    }
}

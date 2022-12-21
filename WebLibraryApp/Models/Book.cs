namespace WebLibraryApp.Models
{
    public class Book : BaseModel
    {
        public string Title { get; set; } = string.Empty;

        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }

        public Guid? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public int YearPublished { get; set; }

        public IEnumerable<Authorship> Authorship { get; set; } = new List<Authorship>();
    }
}

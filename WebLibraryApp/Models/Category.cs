namespace WebLibraryApp.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}

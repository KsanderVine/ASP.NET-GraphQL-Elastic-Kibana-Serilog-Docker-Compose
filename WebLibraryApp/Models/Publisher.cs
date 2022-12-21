namespace WebLibraryApp.Models
{
    public class Publisher : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}

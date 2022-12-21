namespace WebLibraryApp.Models
{
    public class Writer : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Authorship> Authorship { get; set; } = new List<Authorship>();
    }
}

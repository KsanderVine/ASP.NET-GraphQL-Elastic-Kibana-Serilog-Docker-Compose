namespace WebLibraryApp.Options
{
    public class ElasticsearchOptions
    {
        public const string Section = nameof(ElasticsearchOptions);

        public string? ApplicationName { get; set; }
        public string? ConnectionUsername { get; set; }
        public string? ConnectionPassword { get; set; }
        public List<string> Nodes { get; set; } = new List<string>();
    }
}

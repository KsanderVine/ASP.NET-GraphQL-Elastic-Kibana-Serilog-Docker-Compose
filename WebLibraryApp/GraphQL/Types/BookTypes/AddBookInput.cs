namespace WebLibraryApp.GraphQL.Types.BookTypes
{
    public record AddBookInput(string Title, int YearPublished, Guid? PublisherId, Guid? CategoryId);
}

namespace WebLibraryApp.GraphQL.Types.AuthorshipTypes
{
    public record AddAuthorshipInput(Guid WriterId, Guid BookId);
}

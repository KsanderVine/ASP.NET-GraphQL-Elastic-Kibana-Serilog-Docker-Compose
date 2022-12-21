using AutoMapper;
using WebLibraryApp.Models;
using WebLibraryApp.GraphQL.Types.BookTypes;
using WebLibraryApp.GraphQL.Types.WriterTypes;
using WebLibraryApp.GraphQL.Types.CategoryTypes;
using WebLibraryApp.GraphQL.Types.PublisherTypes;
using WebLibraryApp.GraphQL.Types.AuthorshipTypes;

namespace WebLibraryApp.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<AddBookInput, Book>();
            CreateMap<AddWriterInput, Book>();
            CreateMap<AddCategoryInput, Book>();
            CreateMap<AddPublisherInput, Book>();
            CreateMap<AddAuthorshipInput, Book>();
        }
    }
}

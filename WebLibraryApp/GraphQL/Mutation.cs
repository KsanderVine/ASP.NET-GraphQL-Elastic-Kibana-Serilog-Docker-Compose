using AutoMapper;
using WebLibraryApp.GraphQL.Types.BookTypes;
using WebLibraryApp.GraphQL.Types.CategoryTypes;
using WebLibraryApp.GraphQL.Types.PublisherTypes;
using WebLibraryApp.GraphQL.Types.WriterTypes;
using WebLibraryApp.GraphQL.Types.AuthorshipTypes;
using WebLibraryApp.Models;
using WebLibraryApp.Data;

namespace WebLibraryApp.GraphQL
{
    public class Mutation
    {
        public async Task<AddBookPayload> AddBook(
            AddBookInput input,
            AppDbContext context,
            [Service] IMapper mapper,
            [Service] ILogger<Mutation> logger,
            CancellationToken cancellationToken)
        {
            logger.LogInformation("GraphQL request \"{type}\" processed by method \"{method}\"",
                nameof(Mutation),
                nameof(AddBook));
            var book = mapper.Map<Book>(input);
            await context.Books.AddAsync(book, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return new AddBookPayload(book);
        }

        public async Task<AddWriterPayload> AddWriter(
            AddWriterInput input,
            AppDbContext context,
            [Service] IMapper mapper,
            [Service] ILogger<Mutation> logger,
            CancellationToken cancellationToken)
        {
            logger.LogInformation("GraphQL request \"{type}\" processed by method \"{method}\"",
                nameof(Mutation),
                nameof(AddWriter));
            var writer = mapper.Map<Writer>(input);
            await context.Writers.AddAsync(writer, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return new AddWriterPayload(writer);
        }

        public async Task<AddCategoryPayload> AddCategory(
            AddCategoryInput input,
            AppDbContext context,
            [Service] IMapper mapper,
            [Service] ILogger<Mutation> logger,
            CancellationToken cancellationToken)
        {
            logger.LogInformation("GraphQL request \"{type}\" processed by method \"{method}\"",
                nameof(Mutation),
                nameof(AddCategory));
            var category = mapper.Map<Category>(input);
            await context.Categories.AddAsync(category, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return new AddCategoryPayload(category);
        }

        public async Task<AddPublisherPayload> AddPublisher(
            AddPublisherInput input,
            AppDbContext context,
            [Service] IMapper mapper,
            [Service] ILogger<Mutation> logger,
            CancellationToken cancellationToken)
        {
            logger.LogInformation("GraphQL request \"{type}\" processed by method \"{method}\"",
                nameof(Mutation),
                nameof(AddPublisher));
            var publisher = mapper.Map<Publisher>(input);
            await context.Publishers.AddAsync(publisher, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return new AddPublisherPayload(publisher);
        }

        public async Task<AddAuthorshipPayload> AddAuthorship(
            AddAuthorshipInput input,
            AppDbContext context,
            [Service] IMapper mapper,
            [Service] ILogger<Mutation> logger,
            CancellationToken cancellationToken)
        {
            logger.LogInformation("GraphQL request \"{type}\" processed by method \"{method}\"",
                nameof(Mutation),
                nameof(AddAuthorship));
            var authorship = mapper.Map<Authorship>(input);
            await context.Authorship.AddAsync(authorship, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return new AddAuthorshipPayload(authorship);
        }
    }
}

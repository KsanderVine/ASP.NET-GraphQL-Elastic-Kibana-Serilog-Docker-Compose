using WebLibraryApp.Models;
using WebLibraryApp.Data;

namespace WebLibraryApp.GraphQL
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBook([Service] ILogger<Query> logger, AppDbContext context)
        {
            logger.LogInformation("GraphQL request \"{type}\" processed by method \"{method}\"", 
                nameof(Query), 
                nameof(GetBook));
            return context.Books;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Writer> GetWriter([Service] ILogger<Query> logger, AppDbContext context)
        {
            logger.LogInformation("GraphQL request \"{type}\" processed by method \"{method}\"", 
                nameof(Query), 
                nameof(GetWriter));
            return context.Writers;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Publisher> GetPublisher([Service] ILogger<Query> logger, AppDbContext context)
        {
            logger.LogInformation("GraphQL request \"{type}\" processed by method \"{method}\"", 
                nameof(Query),
                nameof(GetPublisher));
            return context.Publishers;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Category> GetCategory([Service] ILogger<Query> logger, AppDbContext context)
        {
            logger.LogInformation("GraphQL request \"{type}\" processed by method \"{method}\"", 
                nameof(Query), 
                nameof(GetCategory));
            return context.Categories;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Authorship> GetAuthorship([Service] ILogger<Query> logger, AppDbContext context)
        {
            logger.LogInformation("GraphQL request \"{type}\" processed by method \"{method}\"", 
                nameof(Query), 
                nameof(GetAuthorship));
            return context.Authorship;
        }
    }
}

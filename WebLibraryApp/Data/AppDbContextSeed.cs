using Microsoft.EntityFrameworkCore;
using WebLibraryApp.Models;

namespace WebLibraryApp.Data
{
    public static class AppDbContextSeed
    {
        public static async Task Seed(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using var scope = app.ApplicationServices.CreateScope();

            await SeedDataAsync(scope, env);
        }

        private static async Task SeedDataAsync(IServiceScope scope, IWebHostEnvironment env)
        {
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
            using var context = await contextFactory.CreateDbContextAsync();
            //using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            using var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("AppDbContextSeed");

            if (env.IsProduction())
            {
                logger.LogInformation("Attempting to apply migrations...");
                try
                {
                    await context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Could not apply migrations");
                }
            }

            string? useDevelopmentSeed = Environment.GetEnvironmentVariable("USE_DEVELOPMENT_SEED");
            if (env.IsDevelopment() || string.Equals(useDevelopmentSeed, "TRUE"))
            {
                if (context.Categories.Any())
                {
                    logger.LogInformation("Seeding already done...");
                    return;
                }

                logger.LogInformation("Seeding development data...");
                var categories = new List<Category>()
                {
                    new Category { Name = "Classics" },
                    new Category { Name = "Fantasy" },
                    new Category { Name = "Action and Adventure" },
                    new Category { Name = "Comic Book or Graphic Novel" },
                    new Category { Name = "Detective and Mystery" },
                    new Category { Name = "Sci-Fi" }
                };
                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();

                var publishers = new List<Publisher>()
                {
                    new Publisher { Name = "Pearson" },
                    new Publisher { Name = "Reed Elsevier" },
                    new Publisher { Name = "Thomson-Reuters" },
                    new Publisher { Name = "Wolters Kluwer" },
                    new Publisher { Name = "Random House" },
                    new Publisher { Name = "Hachette Livre" },
                    new Publisher { Name = "Holtzbrinck" },
                    new Publisher { Name = "Grupo Planeta" },
                    new Publisher { Name = "Wiley" }
                };
                await context.Publishers.AddRangeAsync(publishers);
                await context.SaveChangesAsync();

                var writers = new List<Writer>()
                {
                    new Writer { Name = "Leo Tolstoy" },
                    new Writer { Name = "William Shakespeare" },
                    new Writer { Name = "John Ronald Reuel Tolkien" },
                    new Writer { Name = "George R. R. Martin" },
                    new Writer { Name = "Stan Lee" },
                    new Writer { Name = "Gerry Conway" },
                    new Writer { Name = "Daria Dontsova" },
                    new Writer { Name = "Isaac Asimov" }
                };
                await context.Writers.AddRangeAsync(writers);
                await context.SaveChangesAsync();

                var books = new List<Book>()
                {
                    new Book
                    {
                        Title = "War and Peace",
                        Category = categories[0],
                        Publisher = publishers[0],
                        YearPublished = 1965
                    },
                    new Book
                    {
                        Title = "Anna Karenina",
                        Category = categories[0],
                        Publisher = publishers[4],
                        YearPublished = 1979
                    },
                    new Book
                    {
                        Title = "Resurrection",
                        Category = categories[0],
                        Publisher = publishers[8],
                        YearPublished = 1999
                    },
                    new Book
                    {
                        Title = "The Tragedy of Macbeth",
                        Category = categories[0],
                        Publisher = publishers[1],
                        YearPublished = 2019
                    },
                    new Book
                    {
                        Title = "Hamlet",
                        Category = categories[0],
                        Publisher = publishers[6],
                        YearPublished = 2005
                    },
                    new Book
                    {
                        Title = "Othello",
                        Category = categories[0],
                        Publisher = publishers[8],
                        YearPublished = 1999
                    },
                    new Book
                    {
                        Title = "The Hobbit",
                        Category = categories[1],
                        Publisher = publishers[1],
                        YearPublished = 2000
                    },
                    new Book
                    {
                        Title = "The Lord of the Rings",
                        Category = categories[1],
                        Publisher = publishers[1],
                        YearPublished = 2001
                    },
                    new Book
                    {
                        Title = "The Silmarillion",
                        Category = categories[1],
                        Publisher = publishers[1],
                        YearPublished = 2003
                    },
                    new Book
                    {
                        Title = "Fire & Blood",
                        Category = categories[2],
                        Publisher = publishers[3],
                        YearPublished = 2010
                    },
                    new Book
                    {
                        Title = "A Feast for Crows",
                        Category = categories[2],
                        Publisher = publishers[0],
                        YearPublished = 2020
                    },
                    new Book
                    {
                        Title = "A Dance with Dragons",
                        Category = categories[2],
                        Publisher = publishers[1],
                        YearPublished = 2014
                    },
                    new Book
                    {
                        Title = "Just Imagine...",
                        Category = categories[3],
                        Publisher = publishers[6],
                        YearPublished = 2012
                    },
                    new Book
                    {
                        Title = "The Amazing Spider-Man",
                        Category = categories[3],
                        Publisher = publishers[7],
                        YearPublished = 2013
                    },
                    new Book
                    {
                        Title = "The Mighty Thor",
                        Category =categories[3],
                        Publisher = publishers[8],
                        YearPublished = 2014
                    },
                    new Book
                    {
                        Title = "The Midnight Dancers",
                        Category = categories[3],
                        Publisher = publishers[8],
                        YearPublished = 2011
                    },
                    new Book
                    {
                        Title = "Universe 1.",
                        Category = categories[3],
                        Publisher = publishers[8],
                        YearPublished = 2011
                    },
                    new Book
                    {
                        Title = "Krutyye naslednichki",
                        Category = categories[4],
                        Publisher = publishers[5],
                        YearPublished = 2022
                    },
                    new Book
                    {
                        Title = "Za vsemi zaytsami",
                        Category = categories[4],
                        Publisher = publishers[4],
                        YearPublished = 2021
                    },
                    new Book
                    {
                        Title = "Dama s kogotkami",
                        Category = categories[4],
                        Publisher = publishers[3],
                        YearPublished = 2020
                    },
                    new Book
                    {
                        Title = "Stowaway",
                        Category = categories[5],
                        Publisher = publishers[1],
                        YearPublished = 2001
                    },
                    new Book
                    {
                        Title = "Nightfall",
                        Category = categories[5],
                        Publisher = publishers[1],
                        YearPublished = 2002
                    }
                };
                await context.Books.AddRangeAsync(books);
                await context.SaveChangesAsync();

                var authorship = new List<Authorship>()
                {
                    new Authorship { Writer = writers[0], Book = books[0] },
                    new Authorship { Writer = writers[0], Book = books[1] },
                    new Authorship { Writer = writers[0], Book = books[2] },
                    new Authorship { Writer = writers[1], Book = books[3] },
                    new Authorship { Writer = writers[1], Book = books[4] },
                    new Authorship { Writer = writers[1], Book = books[5] },
                    new Authorship { Writer = writers[2], Book = books[6] },
                    new Authorship { Writer = writers[2], Book = books[7] },
                    new Authorship { Writer = writers[2], Book = books[8] },
                    new Authorship { Writer = writers[3], Book = books[9] },
                    new Authorship { Writer = writers[3], Book = books[10] },
                    new Authorship { Writer = writers[3], Book = books[11] },
                    new Authorship { Writer = writers[4], Book = books[12] },
                    new Authorship { Writer = writers[4], Book = books[13] },
                    new Authorship { Writer = writers[4], Book = books[14] },
                    new Authorship { Writer = writers[5], Book = books[15] },
                    new Authorship { Writer = writers[5], Book = books[16] },
                    new Authorship { Writer = writers[6], Book = books[17] },
                    new Authorship { Writer = writers[6], Book = books[18] },
                    new Authorship { Writer = writers[6], Book = books[19] },
                    new Authorship { Writer = writers[7], Book = books[20] },
                    new Authorship { Writer = writers[7], Book = books[21] }
                };
                await context.Authorship.AddRangeAsync(authorship);
                await context.SaveChangesAsync();

                logger.LogInformation("Data seeded...");
            }
        }
    }
}

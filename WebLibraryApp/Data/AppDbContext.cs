using Microsoft.EntityFrameworkCore;
using WebLibraryApp.Models;

namespace WebLibraryApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Writer> Writers { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;
        public DbSet<Authorship> Authorship { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            CreateBookModel(modelBuilder);

            CreateCategoryModel(modelBuilder);

            CreatePublisherModel(modelBuilder);

            CreateWriterModel(modelBuilder);

            CreateAuthorshipModel(modelBuilder);

            static void CreateBookModel(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Book>()
                    .Property(e => e.Id)
                    .HasDefaultValueSql("NEWSEQUENTIALID()");

                modelBuilder.Entity<Book>()
                    .Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                modelBuilder.Entity<Book>()
                    .Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                modelBuilder.Entity<Book>()
                    .HasOne(e => e.Category)
                    .WithMany(e => e.Books)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);

                modelBuilder.Entity<Book>()
                    .HasOne(e => e.Publisher)
                    .WithMany(e => e.Books)
                    .HasForeignKey(e => e.PublisherId)
                    .OnDelete(DeleteBehavior.SetNull);
            }

            static void CreateCategoryModel(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Category>()
                    .Property(e => e.Id)
                    .HasDefaultValueSql("NEWSEQUENTIALID()");

                modelBuilder.Entity<Category>()
                    .Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                modelBuilder.Entity<Category>()
                    .Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");
            }

            static void CreatePublisherModel(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Publisher>()
                    .Property(e => e.Id)
                    .HasDefaultValueSql("NEWSEQUENTIALID()");

                modelBuilder.Entity<Publisher>()
                    .Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                modelBuilder.Entity<Publisher>()
                    .Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");
            }

            static void CreateWriterModel(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Writer>()
                    .Property(e => e.Id)
                    .HasDefaultValueSql("NEWSEQUENTIALID()");

                modelBuilder.Entity<Writer>()
                    .Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                modelBuilder.Entity<Writer>()
                    .Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");
            }

            static void CreateAuthorshipModel(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Authorship>()
                    .HasKey(e => new { e.WriterId, e.BookId });

                modelBuilder.Entity<Authorship>()
                    .HasOne(e => e.Writer)
                    .WithMany(e => e.Authorship)
                    .HasForeignKey(e => e.WriterId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Authorship>()
                    .HasOne(e => e.Book)
                    .WithMany(e => e.Authorship)
                    .HasForeignKey(e => e.BookId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }
    }
}

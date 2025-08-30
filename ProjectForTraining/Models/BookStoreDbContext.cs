using Microsoft.EntityFrameworkCore;

namespace ProjectForTraining.Models
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Author entity
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
            });

            // Configure Book entity
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.HasOne(e => e.Author)
                      .WithMany()
                      .HasForeignKey(e => e.AuthorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Seed Data
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FullName = "Yazeed Abusalameh" },
                new Author { Id = 2, FullName = "Ahmed Ali" },
                new Author { Id = 3, FullName = "Sara Mohammed" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "C# Programming", Description = "Learn C# programming language", AuthorId = 1 },
                new Book { Id = 2, Title = "Java Programming", Description = "Learn Java programming language", AuthorId = 2 },
                new Book { Id = 3, Title = "Python Programming", Description = "Learn Python programming language", AuthorId = 3 }
            );
        }
    }
}

using Domain;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> opt):base(opt)=>Database.EnsureCreated();
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Editor> Editors { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookEditor> BookEditors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.AuthorId, ba.BookIsbn });
        modelBuilder.Entity<BookEditor>().HasKey(be => new { be.EditorId, be.BookIsbn });
        base.OnModelCreating(modelBuilder);
    }
}

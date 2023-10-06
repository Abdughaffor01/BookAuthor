using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Book
{
    [Key]
    public int Isbn { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }
    public decimal Price { get; set; }
    [MaxLength(50)]
    public string Advance { get; set; }
    public int Ytdsales { get; set; }
    public DateTime PubDate { get; set; }
    public List<BookEditor> BookEditors { get; set; }
    public List<BookAuthor> BookAuthors { get; set; }
}
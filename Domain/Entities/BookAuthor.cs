namespace Domain;
public class BookAuthor
{
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public int BookIsbn{ get; set; }
    public Book Book { get; set; }
    public int AuthorOrder { get; set; }
    public decimal RoyaltyShare { get; set; }
}

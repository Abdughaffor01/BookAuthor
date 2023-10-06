using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Author
{
    [Key]
    public int AuthorId { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    [MaxLength(13)]
    public string Phone { get; set; }
    [MaxLength(100)]
    public string Address { get; set; }
    [MaxLength(50)]
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public List<BookAuthor> BookAuthors { get; set; }
}

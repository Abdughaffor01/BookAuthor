using System.ComponentModel.DataAnnotations;
namespace Domain;
public class Publisher
{
    [Key]
    public int PublisherId { get; set; }
    [MaxLength(50)]
    public string Address { get; set; }
    [MaxLength(50)]
    public string City { get; set; }
    [MaxLength(50)]
    public string State { get; set; }
    public List<Book> Books { get; set; }
}

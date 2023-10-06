using System.ComponentModel.DataAnnotations;

namespace Domain;
public class BaseBookDto
{
    public int Isbn { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public int PublisherId { get; set; }
    public decimal Price { get; set; }
    public string Advance { get; set; }
    public int Ytdsales { get; set; }
}

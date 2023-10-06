using System.ComponentModel.DataAnnotations;

namespace Domain;
public class BasePublisherDto
{
    public int PublisherId { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}

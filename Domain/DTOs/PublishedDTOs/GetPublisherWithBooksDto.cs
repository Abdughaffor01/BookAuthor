namespace Domain;
public class GetPublisherWithBooksDto:BasePublisherDto
{
    public List<Book> Books { get; set; }=new List<Book>();
}

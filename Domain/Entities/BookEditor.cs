namespace Domain;
public class BookEditor
{
    public int EditorId { get; set; }
    public int BookIsbn { get; set; }
    public Editor Editor { get; set; }
    public Book Book { get; set; }
}

namespace Domain;
public class GetAuthorWithBookDto:BaseAuthorDto
{
    public List<BookAuthor> BookAuthors { get; set; }=new List<BookAuthor>();
}

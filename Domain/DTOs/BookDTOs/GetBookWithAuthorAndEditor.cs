namespace Domain;
public class GetBookWithAuthorAndEditor:BaseBookDto
{

    public List<BookEditor> BookEditors { get; set; }
    public List<BookAuthor> BookAuthors { get; set; }
}

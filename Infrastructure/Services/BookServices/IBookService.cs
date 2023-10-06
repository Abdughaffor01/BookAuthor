using Domain;

namespace Infrastructure;
public interface IBookService
{
    Task<Response<List<GetBookDto>>> GetBooksAsync();
    Task<Response<GetBookWithAuthorAndEditor>> GetBookByIdAsync(int id);
    Task<Response<AddBookDto>> AddBookAsync(AddBookDto model,int? editorId);
    Task<Response<AddBookDto>> UpdateBookAsync(AddBookDto model);
    Task<Response<string>> DeleteBookAsync(int id);
}

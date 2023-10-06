using Domain;

namespace Infrastructure;
public interface IAuthorService
{
    Task<Response<List<GetAuthorDto>>> GetAuthorsAsync();
    Task<Response<GetAuthorWithBookDto>> GetAuthorByIdAsync(int id);
    Task<Response<AddAuthorDto>> AddAuthorAsync(AddAuthorDto model);
    Task<Response<AddAuthorDto>> UpdateAuthorAsync(AddAuthorDto model);
    Task<Response<string>> DeleteAuthorAsync(int id);
}

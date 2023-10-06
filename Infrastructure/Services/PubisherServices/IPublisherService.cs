using Domain;
namespace Infrastructure;
public interface IPublisherService
{
    Task<Response<List<GetPublisherDto>>> GetPublishersAsync();
    Task<Response<GetPublisherWithBooksDto>> GetPublisherByIdAsync(int id);
    Task<Response<AddPublisherDto>> AddPublisherAsync(AddPublisherDto model);
    Task<Response<AddPublisherDto>> UpdatePublisherAsync(AddPublisherDto model);
    Task<Response<string>> DeletePublisherAsync(int id);
}

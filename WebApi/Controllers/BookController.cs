using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]
public class BookController:ControllerBase
{
    private readonly IBookService _service;
    public BookController(IBookService service)=>_service = service;

    [HttpGet("GetBooksAsync")]
    public async Task<Response<List<GetBookDto>>> GetBooksAsync()=>await _service.GetBooksAsync();
     
    [HttpGet("GetBookByIdAsync")]
    public async Task<Response<GetBookWithAuthorAndEditor>> GetBookByIdAsync(int id)=>await _service.GetBookByIdAsync(id);

    [HttpPost("AddBookAsync")]
    public async Task<Response<AddBookDto>> AddBookAsync([FromBody]AddBookDto model,int? id)=>await _service.AddBookAsync(model,id);

    [HttpDelete("DeleteBookAsync")]
    public async Task<Response<string>> DeleteBookAsync(int id)=>await _service.DeleteBookAsync(id);

    [HttpPut("UpdateBookAsync")]
    public async Task<Response<AddBookDto>> UpdateBookAsync([FromBody]AddBookDto model)=>await _service.UpdateBookAsync(model);
}

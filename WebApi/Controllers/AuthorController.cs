using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]
public class AuthorController:ControllerBase
{
    private readonly IAuthorService _service;
    public AuthorController(IAuthorService service)=>_service = service;

    [HttpGet("GetAuthorsAsync")]
    public async Task<Response<List<GetAuthorDto>>> GetAuthorsAsync()=>await _service.GetAuthorsAsync();

    [HttpGet("GetAuthorByIdAsync")]
    public async Task<Response<GetAuthorWithBookDto>> GetAuthorByIdAsync(int id)=>await _service.GetAuthorByIdAsync(id);

    [HttpPost("AddAuthorAsync")]
    public async Task<Response<AddAuthorDto>> AddAuthorAsync([FromBody]AddAuthorDto model)=>await _service.AddAuthorAsync(model);

    [HttpDelete("DeleteAuthorAsync")]
    public async Task<Response<string>> DeleteAuthorAsync(int id)=>await _service.DeleteAuthorAsync(id);

    [HttpPut("UpdateAuthorAsync")]
    public async Task<Response<AddAuthorDto>> UpdateAuthorAsync([FromBody]AddAuthorDto model)=>await  _service.UpdateAuthorAsync(model);
}

using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]
public class PublisherController:ControllerBase
{
    private readonly IPublisherService _service;
    public PublisherController(IPublisherService service)=>_service = service;

    [HttpGet("GetPublishersAsync")]
    public async Task<Response<List<GetPublisherDto>>> GetPublishersAsync()=>await _service.GetPublishersAsync();

    [HttpGet("GetPublisherByIdAsync")]
    public async Task<Response<GetPublisherWithBooksDto>> GetPublisherByIdAsync(int id)=>await _service.GetPublisherByIdAsync(id);

    [HttpPost("AddPublisherAsync")]
    public async Task<Response<AddPublisherDto>> AddPublisherAsync([FromBody]AddPublisherDto model)=>await _service.AddPublisherAsync(model);
    [HttpPut("UpdatePublisherAsync")]
    public async Task<Response<AddPublisherDto>> UpdatePublisherAsync(AddPublisherDto model)=>await _service.UpdatePublisherAsync(model);

    [HttpDelete("DeletePublisherAsync")]
    public async Task<Response<string>> DeletePublisherAsync(int id)=>await _service.DeletePublisherAsync(id);
}


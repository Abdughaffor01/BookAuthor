using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace Infrastructure;
public class PublisherService : IPublisherService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    public PublisherService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<AddPublisherDto>> AddPublisherAsync(AddPublisherDto model)
    {
        try
        {
            var publisher = _mapper.Map<Publisher>(model);
            await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();
            return new Response<AddPublisherDto>(model);
        }
        catch (Exception ex)
        {
            return new Response<AddPublisherDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<string>> DeletePublisherAsync(int id)
    {
        try
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null) return new Response<string>(HttpStatusCode.NotFound);
            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted publisher");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<GetPublisherWithBooksDto>> GetPublisherByIdAsync(int id)
    {
        try
        {
            var publisher = await _context.Publishers.Select(p=>new GetPublisherWithBooksDto() { 
                    PublisherId=p.PublisherId,
                    Address=p.Address,
                    City=p.City,
                    State = p.State,
                    Books = p.Books
            }).FirstOrDefaultAsync(x=>x.PublisherId==id);
            if (publisher == null) return new Response<GetPublisherWithBooksDto>(HttpStatusCode.NotFound);
            return new Response<GetPublisherWithBooksDto>(publisher);
        }
        catch (Exception ex)
        {
            return new Response<GetPublisherWithBooksDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<List<GetPublisherDto>>> GetPublishersAsync()
    {
        try
        {
            var publishers = await _context.Publishers.ToListAsync();
            if (publishers.Count == 0) return new Response<List<GetPublisherDto>>(HttpStatusCode.NotFound);
            var mapPublishers=_mapper.Map<List<GetPublisherDto>>(publishers);
            return new Response<List<GetPublisherDto>>(mapPublishers);
        }
        catch (Exception ex)
        {
            return new Response<List<GetPublisherDto>>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<AddPublisherDto>> UpdatePublisherAsync(AddPublisherDto model)
    {
        try
        {
            var publisher = await _context.Publishers.FindAsync(model.PublisherId);
            if (publisher == null) return new Response<AddPublisherDto>(HttpStatusCode.NotFound);
            _mapper.Map(model,publisher);
            await _context.SaveChangesAsync();
            return new Response<AddPublisherDto>(model);
        }
        catch (Exception ex)
        {
            return new Response<AddPublisherDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
}

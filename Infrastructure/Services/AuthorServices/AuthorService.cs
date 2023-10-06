using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure;
public class AuthorService : IAuthorService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    public AuthorService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<AddAuthorDto>> AddAuthorAsync(AddAuthorDto model)
    {
        try
        {
            var author = _mapper.Map<Author>(model);
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return new Response<AddAuthorDto>(_mapper.Map<AddAuthorDto>(author));
        }
        catch (Exception ex)
        {
            return new Response<AddAuthorDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<string>> DeleteAuthorAsync(int id)
    {
        try
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return new Response<string>(HttpStatusCode.NotFound);
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted author");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<GetAuthorWithBookDto>> GetAuthorByIdAsync(int id)
    {
        try
        {
            var author=await _context.Authors.Select(a=>new GetAuthorWithBookDto() { 
                AuthorId = a.AuthorId,
                Address = a.Address,
                BookAuthors = a.BookAuthors,
                City = a.City,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Phone = a.Phone,
                State = a.State,
                Zip = a.Zip
            }).FirstOrDefaultAsync(x=>x.AuthorId==id);
            if (author == null) return new Response<GetAuthorWithBookDto>(HttpStatusCode.NotFound);
            return new Response<GetAuthorWithBookDto>(author);
        }
        catch (Exception ex)
        {
            return new Response<GetAuthorWithBookDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<List<GetAuthorDto>>> GetAuthorsAsync()
    {
        try
        {
            var authors=await _context.Authors.ToListAsync();
            if (authors.Count == 0) return new Response<List<GetAuthorDto>>(HttpStatusCode.NoContent);
            var mapAuthors = _mapper.Map<List<GetAuthorDto>>(authors);
            return new Response<List<GetAuthorDto>>(mapAuthors);
        }
        catch (Exception ex)
        {
            return new Response<List<GetAuthorDto>>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<AddAuthorDto>> UpdateAuthorAsync(AddAuthorDto model)
    {
        try
        {
            var author = await _context.Authors.FindAsync(model.AuthorId);
            if(author==null)return new Response<AddAuthorDto>(HttpStatusCode.NotFound);
            _mapper.Map(model, author);
            await _context.SaveChangesAsync();
            return new Response<AddAuthorDto>(_mapper.Map<AddAuthorDto>(author));
        }
        catch (Exception ex)
        {
            return new Response<AddAuthorDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
}

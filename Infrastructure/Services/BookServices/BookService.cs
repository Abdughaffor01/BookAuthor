using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure;
public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    public BookService(IMapper mapper,DataContext context)
    {
        _context = context;
        _mapper = mapper;   
    }
    public async Task<Response<AddBookDto>> AddBookAsync(AddBookDto model, int? editorId)
    {
        try
        {
            var book = _mapper.Map<Book>(model);
            book.PubDate = DateTime.UtcNow;
            await _context.Books.AddAsync(book);
            if (editorId != null) {
                var editor = await _context.Editors.FindAsync(editorId);
                if (editor == null) return new Response<AddBookDto>(HttpStatusCode.NotFound,"not found editor");
                var editorWithBook = new BookEditor() { 
                    BookIsbn=model.Isbn,
                    EditorId=editor.EditorId
                };
                await _context.BookEditors.AddAsync(editorWithBook);
            }
            await _context.SaveChangesAsync();
            return new Response<AddBookDto>(_mapper.Map<AddBookDto>(book));
        }
        catch (Exception ex)
        {
            return new Response<AddBookDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<string>> DeleteBookAsync(int id)
    {
        try
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return new Response<string>(HttpStatusCode.NotFound);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted book");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<GetBookWithAuthorAndEditor>> GetBookByIdAsync(int id)
    {
        try
        {
            var book = await _context.Books.Select(b=>new GetBookWithAuthorAndEditor() { 
                Isbn=b.Isbn,
                PublisherId=b.PublisherId,
                Advance=b.Advance,
                Price = b.Price,
                Title = b.Title,
                Type = b.Type,
                Ytdsales = b.Ytdsales,
                BookAuthors = b.BookAuthors,
                BookEditors = b.BookEditors
            }).FirstOrDefaultAsync(bk=>bk.Isbn==id);
            if (book == null) return new Response<GetBookWithAuthorAndEditor>(HttpStatusCode.NotFound);
            return new Response<GetBookWithAuthorAndEditor>(book);
        }
        catch (Exception ex)
        {
            return new Response<GetBookWithAuthorAndEditor>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<List<GetBookDto>>> GetBooksAsync()
    {
        try
        {
            var books=await _context.Books.ToListAsync();
            if (books.Count == 0) return new Response<List<GetBookDto>>(HttpStatusCode.NotFound);
            var mapBooks = _mapper.Map<List<GetBookDto>>(books);
            return new Response<List<GetBookDto>>(mapBooks);
        }
        catch (Exception ex)
        {
            return new Response<List<GetBookDto>>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<AddBookDto>> UpdateBookAsync(AddBookDto model)
    {
        try
        {
            var book = await _context.Books.FindAsync(model.Isbn);
            if (book == null) return new Response<AddBookDto>(HttpStatusCode.NotFound);
            _mapper.Map(model,book);
            await _context.SaveChangesAsync();
            return new Response<AddBookDto>(_mapper.Map<AddBookDto>(book));
        }
        catch (Exception ex)
        {
            return new Response<AddBookDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
}

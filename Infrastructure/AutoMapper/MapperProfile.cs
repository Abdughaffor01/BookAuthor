using AutoMapper;
using Domain;

namespace Infrastructure;
public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<AddPublisherDto,Publisher>().ReverseMap();
        CreateMap<GetPublisherWithBooksDto,Publisher>().ReverseMap();
        CreateMap<GetPublisherDto,Publisher>().ReverseMap();

        CreateMap<AddBookDto, Book>().ReverseMap();
        CreateMap<GetBookDto, Book>().ReverseMap();
        CreateMap<GetBookWithAuthorAndEditor, Book>().ReverseMap();

        CreateMap<AddAuthorDto,Author>().ReverseMap();
        CreateMap<GetAuthorDto,Author>().ReverseMap();
    }
}

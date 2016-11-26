using AutoMapper;
using FunctionalDecomposition.DataTransferObjects;
using FunctionalDecomposition.Models;

namespace FunctionalDecomposition.Profiles
{
  public sealed class BookProfile : Profile
  {
    public BookProfile()
    {
      this.CreateMap<BookDto, Book>();
      this.CreateMap<Book, BookDto>();
    }
  }
}

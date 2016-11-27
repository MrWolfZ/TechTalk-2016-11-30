using AutoMapper;
using VolatilityDecomposition.DataTransferObjects;
using VolatilityDecomposition.Models;

namespace VolatilityDecomposition.Profiles
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

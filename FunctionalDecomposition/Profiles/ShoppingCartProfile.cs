using AutoMapper;
using FunctionalDecomposition.DataTransferObjects;
using FunctionalDecomposition.Models;

namespace FunctionalDecomposition.Profiles
{
  public sealed class ShoppingCartProfile : Profile
  {
    public ShoppingCartProfile()
    {
      this.CreateMap<ShoppingCartDto, ShoppingCart>();
      this.CreateMap<ShoppingCart, ShoppingCartDto>();
    }
  }
}
using AutoMapper;
using VolatilityDecomposition.DataTransferObjects;
using VolatilityDecomposition.Models;

namespace VolatilityDecomposition.Profiles
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
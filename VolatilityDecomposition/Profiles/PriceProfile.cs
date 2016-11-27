using AutoMapper;
using VolatilityDecomposition.DataTransferObjects;
using VolatilityDecomposition.Models;

namespace VolatilityDecomposition.Profiles
{
  public sealed class PriceProfile : Profile
  {
    public PriceProfile()
    {
      this.CreateMap<PriceDto, Price>();
      this.CreateMap<Price, PriceDto>();
    }
  }
}
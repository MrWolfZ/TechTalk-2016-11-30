using AutoMapper;
using FunctionalDecomposition.DataTransferObjects;
using FunctionalDecomposition.Models;

namespace FunctionalDecomposition.Profiles
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
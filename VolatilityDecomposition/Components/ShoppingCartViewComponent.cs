using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VolatilityDecomposition.DataTransferObjects;
using VolatilityDecomposition.Services.Interfaces;

namespace VolatilityDecomposition.Components
{
  public sealed class ShoppingCartViewComponent : ViewComponent
  {
    private readonly IShoppingCartService shoppingCartService;
    private readonly IMapper mapper;

    public ShoppingCartViewComponent(IShoppingCartService shoppingCartService, IMapper mapper)
    {
      this.shoppingCartService = shoppingCartService;
      this.mapper = mapper;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
      var model = await this.shoppingCartService.GetForCurrentUserAsync();
      var dto = this.mapper.Map<ShoppingCartDto>(model);
      return this.View(dto);
    }
  }
}

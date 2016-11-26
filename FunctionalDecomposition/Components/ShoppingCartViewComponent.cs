using System.Threading.Tasks;
using AutoMapper;
using FunctionalDecomposition.DataTransferObjects;
using FunctionalDecomposition.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FunctionalDecomposition.Components
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

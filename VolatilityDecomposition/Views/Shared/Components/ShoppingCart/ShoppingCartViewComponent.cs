using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VolatilityDecomposition.ShoppingCart;

namespace VolatilityDecomposition.Views.Shared.Components.ShoppingCart
{
  public sealed class ShoppingCartViewComponent : ViewComponent
  {
    private readonly IShoppingCartService shoppingCartService;

    public ShoppingCartViewComponent(IShoppingCartService shoppingCartService)
    {
      this.shoppingCartService = shoppingCartService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
      var model = await this.shoppingCartService.GetForCurrentUserAsync();
      return this.View(Dto.ShoppingCart.CreateFrom(model));
    }
  }
}

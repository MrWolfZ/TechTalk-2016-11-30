using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VolatilityDecomposition.ShoppingCart;

namespace VolatilityDecomposition.Views.Shared.Components.ShoppingCart
{
  [Route("api/[controller]")]
  public class ShoppingCartController : Controller
  {
    private readonly IShoppingCartService shoppingCartService;

    public ShoppingCartController(IShoppingCartService shoppingCartService)
    {
      this.shoppingCartService = shoppingCartService;
    }

    [HttpPost("books/{id}")]
    public async Task<ActionResult> RemoveBook(string id, string q)
    {
      await this.shoppingCartService.RemoveBookAsync(id);
      return this.RedirectToAction("Index", "Books", new { q });
    }
  }
}

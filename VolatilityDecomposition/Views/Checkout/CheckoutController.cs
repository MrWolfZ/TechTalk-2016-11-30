using Microsoft.AspNetCore.Mvc;

namespace VolatilityDecomposition.Views.Checkout
{
  public class CheckoutController : Controller
  {
    public IActionResult Index()
    {
      return this.View();
    }
  }
}
using Microsoft.AspNetCore.Mvc;

namespace VolatilityDecomposition.Controllers
{
  public class CheckoutController : Controller
  {
    public IActionResult Index()
    {
      return this.View();
    }
  }
}
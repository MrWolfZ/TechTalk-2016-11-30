using Microsoft.AspNetCore.Mvc;

namespace FunctionalDecomposition.Controllers
{
  public class CheckoutController : Controller
  {
    public IActionResult Index()
    {
      return this.View();
    }
  }
}
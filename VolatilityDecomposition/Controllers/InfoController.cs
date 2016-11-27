using Microsoft.AspNetCore.Mvc;

namespace VolatilityDecomposition.Controllers
{
  public class InfoController : Controller
  {
    public IActionResult About()
    {
      return this.View();
    }

    public IActionResult Error()
    {
      return this.View();
    }
  }
}
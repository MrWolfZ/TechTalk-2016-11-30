using System.Web.Mvc;

namespace VolatilityDecomposition.Controllers
{
  [Authorize]
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return this.View();
    }
  }
}

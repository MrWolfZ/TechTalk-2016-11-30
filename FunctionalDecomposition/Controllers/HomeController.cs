using System.Web.Mvc;

namespace FunctionalDecomposition.Controllers
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

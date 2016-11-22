using System.Web.Mvc;

namespace FunctionalDecomposition.Controllers
{
  public class ShoppingCartController : Controller
  {
    public ActionResult Index()
    {
      return this.View();
    }
  }
}
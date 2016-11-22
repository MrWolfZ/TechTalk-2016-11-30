using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using VolatilityDecomposition.Models;

namespace VolatilityDecomposition.Controllers
{
  [Authorize]
  public class MeController : ApiController
  {
    private ApplicationUserManager userManager;

    public MeController()
    {
    }

    public MeController(ApplicationUserManager userManager)
    {
      this.UserManager = userManager;
    }

    public ApplicationUserManager UserManager
    {
      get { return this.userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
      private set { this.userManager = value; }
    }

    // GET api/Me
    public GetViewModel Get()
    {
      var user = this.UserManager.FindById(this.User.Identity.GetUserId());
      return new GetViewModel { Hometown = user.Hometown };
    }
  }
}

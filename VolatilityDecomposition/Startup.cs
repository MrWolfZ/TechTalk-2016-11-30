using Microsoft.Owin;
using Owin;
using VolatilityDecomposition;

[assembly: OwinStartup(typeof(Startup))]

namespace VolatilityDecomposition
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      this.ConfigureAuth(app);
    }
  }
}

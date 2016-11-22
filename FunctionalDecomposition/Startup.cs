using FunctionalDecomposition;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace FunctionalDecomposition
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
    }
  }
}

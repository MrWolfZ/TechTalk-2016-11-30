using Autofac;

namespace VolatilityDecomposition.External.GoogleBooks
{
  public sealed class Module : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<GoogleBooksesApiBooksService>().As<IGoogleBooksService>();
    }
  }
}

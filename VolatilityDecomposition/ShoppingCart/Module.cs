using Autofac;

namespace VolatilityDecomposition.ShoppingCart
{
  public sealed class Module : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<ShoppingCartService>().As<IShoppingCartService>();
    }
  }
}

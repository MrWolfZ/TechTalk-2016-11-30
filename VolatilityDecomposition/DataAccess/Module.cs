using Autofac;
using Microsoft.AspNetCore.Http;

namespace VolatilityDecomposition.DataAccess
{
  public sealed class Module : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
      builder.RegisterGeneric(typeof(HttpSessionRepository<>)).As(typeof(IRepository<>));
    }
  }
}

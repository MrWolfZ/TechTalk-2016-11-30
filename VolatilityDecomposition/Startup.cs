using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace VolatilityDecomposition
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      this.Configuration =
        new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", true, true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
          .AddEnvironmentVariables()
          .Build();
    }

    public IConfigurationRoot Configuration { get; }

    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      services.AddDistributedMemoryCache();
      services.AddSession();

      var builder = new ContainerBuilder();
      builder.RegisterAssemblyModules(typeof(Startup).GetTypeInfo().Assembly);
      builder.Populate(services);

      var container = builder.Build();
      return container.Resolve<IServiceProvider>();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Info/Error");
      }

      app.UseStaticFiles();
      app.UseSession();

      app.UseMvc(
        routes =>
        {
          routes.MapRoute(
            "default",
            "{controller}/{action}/{id?}",
            new { controller = "Books", action = "Index" });
        });
    }
  }
}

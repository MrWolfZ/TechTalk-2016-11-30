using System.Reflection;
using AutoMapper;
using FunctionalDecomposition.DataAccess;
using FunctionalDecomposition.DataAccess.Interfaces;
using FunctionalDecomposition.Services;
using FunctionalDecomposition.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FunctionalDecomposition
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

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      services.AddDistributedMemoryCache();
      services.AddSession();
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

      services.Add(ServiceDescriptor.Transient(typeof(IRepository<>), typeof(HttpSessionRepository<>)));
      services.AddTransient<IBookService, GoogleBooksApiBookService>();
      services.AddTransient<IShoppingCartService, ShoppingCartService>();

      var config = new MapperConfiguration(cfg => cfg.AddProfiles(typeof(Startup).GetTypeInfo().Assembly));
      services.AddSingleton(config.CreateMapper());
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

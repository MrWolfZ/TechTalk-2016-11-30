using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunctionalDecomposition.DataAccess.Interfaces;
using FunctionalDecomposition.Utility;
using Microsoft.AspNetCore.Http;

namespace FunctionalDecomposition.DataAccess
{
  internal class HttpSessionRepository<T> : IRepository<T> where T : IIdentifiable
  {
    private readonly IHttpContextAccessor httpContextAccessor;

    public HttpSessionRepository(IHttpContextAccessor httpContextAccessor)
    {
      this.httpContextAccessor = httpContextAccessor;
    }

    private static string SessionKey => typeof(T).Name;

    private ISession Session => this.httpContextAccessor.HttpContext.Session;

    public IQueryable<T> GetAll()
    {
      var col = this.Session.GetObjectFromJson<ICollection<T>>(SessionKey) ?? new List<T>();
      return col.AsQueryable();
    }

    public Task AddOrUpdateAsync(T item)
    {
      var items = this.GetAll().ToDictionary(i => i.Id);
      items[item.Id] = item;
      this.Session.SetObjectAsJson(SessionKey, items.Values);
      return Task.CompletedTask;
    }
  }
}

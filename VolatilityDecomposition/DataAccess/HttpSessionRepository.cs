using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace VolatilityDecomposition.DataAccess
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

    public IQueryable<T> GetAll() => this.GetCollectionFromSession().AsQueryable();

    public Task AddOrUpdateAsync(T item)
    {
      var items = this.GetAll().ToDictionary(i => i.Id);
      items[item.Id] = item;
      this.UpdateCollectionInSession(items.Values);
      return Task.CompletedTask;
    }

    public void UpdateCollectionInSession(ICollection<T> value) =>
      this.Session.SetString(SessionKey, JsonConvert.SerializeObject(value));

    public ICollection<T> GetCollectionFromSession()
    {
      var value = this.Session.GetString(SessionKey);
      return value == null ? new List<T>() : JsonConvert.DeserializeObject<ICollection<T>>(value);
    }
  }
}

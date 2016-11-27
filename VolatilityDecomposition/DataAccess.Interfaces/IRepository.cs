using System.Linq;
using System.Threading.Tasks;

namespace VolatilityDecomposition.DataAccess.Interfaces
{
  public interface IRepository<T> where T : IIdentifiable
  {
    IQueryable<T> GetAll();

    Task AddOrUpdateAsync(T item);
  }
}

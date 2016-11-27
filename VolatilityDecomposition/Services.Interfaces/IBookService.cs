using System.Collections.Generic;
using System.Threading.Tasks;
using VolatilityDecomposition.Models;

namespace VolatilityDecomposition.Services.Interfaces
{
  public interface IBookService
  {
    Task<ICollection<Book>> Search(string searchTerm);
    Task<ICollection<Book>> Get(IEnumerable<string> ids);
    Task<ICollection<Book>> Get(string id);
  }
}

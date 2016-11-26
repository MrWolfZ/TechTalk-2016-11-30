using System.Collections.Generic;
using System.Threading.Tasks;
using FunctionalDecomposition.Models;

namespace FunctionalDecomposition.Services.Interfaces
{
  public interface IBookService
  {
    Task<ICollection<Book>> Search(string searchTerm);
    Task<ICollection<Book>> Get(IEnumerable<string> ids);
    Task<ICollection<Book>> Get(string id);
  }
}

using System.Threading.Tasks;
using VolatilityDecomposition.Models;

namespace VolatilityDecomposition.Services.Interfaces
{
  public interface IShoppingCartService
  {
    Task<ShoppingCart> GetForCurrentUserAsync();
    Task AddBookAsync(Book book);
    Task RemoveBookAsync(string id);
  }
}

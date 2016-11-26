using System.Threading.Tasks;
using FunctionalDecomposition.Models;

namespace FunctionalDecomposition.Services.Interfaces
{
  public interface IShoppingCartService
  {
    Task<ShoppingCart> GetForCurrentUserAsync();
    Task AddBookAsync(Book book);
  }
}

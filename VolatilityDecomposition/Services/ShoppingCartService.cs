using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolatilityDecomposition.DataAccess.Interfaces;
using VolatilityDecomposition.Models;
using VolatilityDecomposition.Services.Interfaces;

namespace VolatilityDecomposition.Services
{
  internal class ShoppingCartService : IShoppingCartService
  {
    private readonly IRepository<ShoppingCart> shoppingCartRepository;

    public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository)
    {
      this.shoppingCartRepository = shoppingCartRepository;
    }

    public Task<ShoppingCart> GetForCurrentUserAsync()
    {
      var cart = this.shoppingCartRepository.GetAll().FirstOrDefault() ?? CreateEmptyShoppingCart();
      return Task.FromResult(cart);
    }

    public async Task AddBookAsync(Book book)
    {
      var cart = await this.GetForCurrentUserAsync();
      cart.Books.Add(book);
      cart.TotalPrice.Amount += book.Price.Amount;
      await this.shoppingCartRepository.AddOrUpdateAsync(cart);
    }

    public async Task RemoveBookAsync(string id)
    {
      var cart = await this.GetForCurrentUserAsync();
      var book = cart.Books.FirstOrDefault(b => b.Id == id);
      if (book != null)
      {
        cart.Books.Remove(book);
        cart.TotalPrice.Amount -= book.Price.Amount;
      }

      throw new System.NotImplementedException();
    }

    private static ShoppingCart CreateEmptyShoppingCart() => new ShoppingCart
    {
      Id = 1,
      Books = new List<Book>(),
      TotalPrice = new Price
      {
        Amount = 0,
        CurrencyCode = "CHF"
      }
    };
  }
}
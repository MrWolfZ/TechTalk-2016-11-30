using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunctionalDecomposition.DataAccess.Interfaces;
using FunctionalDecomposition.Models;
using FunctionalDecomposition.Services.Interfaces;

namespace FunctionalDecomposition.Services
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
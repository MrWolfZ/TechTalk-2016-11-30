using System;
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
      NormalizeTotalPrice(cart);
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
        NormalizeTotalPrice(cart);
      }

      throw new NotImplementedException();
    }

    private static void NormalizeTotalPrice(ShoppingCart cart)
    {
      if (cart.TotalPrice.Amount < 0.01)
      {
        cart.TotalPrice.Amount = 0;
      }
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

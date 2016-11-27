using System.Linq;
using System.Threading.Tasks;
using VolatilityDecomposition.DataAccess;
using VolatilityDecomposition.External.GoogleBooks;

namespace VolatilityDecomposition.ShoppingCart
{
  public interface IShoppingCartService
  {
    Task<ShoppingCart> GetForCurrentUserAsync();
    Task AddBookAsync(string id);
    Task RemoveBookAsync(string id);
  }

  internal class ShoppingCartService : IShoppingCartService
  {
    private readonly IRepository<ShoppingCart> shoppingCartRepository;
    private readonly IGoogleBooksService booksService;

    public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IGoogleBooksService booksService)
    {
      this.shoppingCartRepository = shoppingCartRepository;
      this.booksService = booksService;
    }

    public Task<ShoppingCart> GetForCurrentUserAsync()
    {
      var cart = this.shoppingCartRepository.GetAll().FirstOrDefault() ?? ShoppingCart.CreateEmpty(0);
      return Task.FromResult(cart);
    }

    public async Task AddBookAsync(string id)
    {
      var book = (await this.booksService.Get(id)).First();
      var cart = await this.GetForCurrentUserAsync();
      cart = cart.With(
        cart.Books.Concat(new[] { ShoppingCart.Book.CreateFrom(book) }).ToList(),
        cart.TotalPrice.With(cart.TotalPrice.Amount + book.Price.Amount)
      );

      await this.shoppingCartRepository.AddOrUpdateAsync(NormalizeTotalPrice(cart));
    }

    public async Task RemoveBookAsync(string id)
    {
      var cart = await this.GetForCurrentUserAsync();
      var book = cart.Books.FirstOrDefault(b => b.Id == id);
      if (book == null)
      {
        return;
      }

      cart = cart.With(
        cart.Books.Where(b => b != book).ToList(),
        cart.TotalPrice.With(cart.TotalPrice.Amount - book.Price.Amount)
      );

      await this.shoppingCartRepository.AddOrUpdateAsync(NormalizeTotalPrice(cart));
    }

    private static ShoppingCart NormalizeTotalPrice(ShoppingCart cart) =>
      cart.TotalPrice.Amount >= 0.01 ? cart : cart.With(totalPrice: cart.TotalPrice.With(0));
  }
}

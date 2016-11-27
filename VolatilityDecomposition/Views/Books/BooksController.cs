using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VolatilityDecomposition.External.GoogleBooks;
using VolatilityDecomposition.ShoppingCart;

namespace VolatilityDecomposition.Views.Books
{
  public class BooksController : Controller
  {
    private readonly IGoogleBooksService booksService;
    private readonly IShoppingCartService shoppingCartService;

    public BooksController(IGoogleBooksService booksService, IShoppingCartService shoppingCartService)
    {
      this.booksService = booksService;
      this.shoppingCartService = shoppingCartService;
    }

    public async Task<IActionResult> Index(string q)
    {
      this.ViewBag.Query = q;

      if (string.IsNullOrEmpty(q))
      {
        return this.View(Dto.BookSearchResult.Empty);
      }

      var books = await this.booksService.Search(q);
      return this.View(Dto.BookSearchResult.CreateFrom(books));
    }

    [HttpPost("addBookToShoppingCart/{id}")]
    public async Task<ActionResult> AddBook(string id, string q)
    {
      await this.shoppingCartService.AddBookAsync(id);
      return this.RedirectToAction("Index", new { q });
    }
  }
}

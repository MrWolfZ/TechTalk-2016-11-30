using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VolatilityDecomposition.DataTransferObjects;
using VolatilityDecomposition.Services.Interfaces;

namespace VolatilityDecomposition.Controllers
{
  [Route("api/[controller]")]
  public class ShoppingCartController : Controller
  {
    private readonly IShoppingCartService shoppingCartService;
    private readonly IBookService bookService;

    public ShoppingCartController(IShoppingCartService shoppingCartService, IBookService bookService)
    {
      this.shoppingCartService = shoppingCartService;
      this.bookService = bookService;
    }

    [HttpPost("books")]
    public async Task<ActionResult> AddBook(BookDto dto, string q)
    {
      var model = (await this.bookService.Get(dto.Id)).First();
      await this.shoppingCartService.AddBookAsync(model);

      return this.RedirectToAction("Index", "Books", new { q });
    }

    [HttpPost("books/{id}")]
    public async Task<ActionResult> RemoveBook(string id, string q)
    {
      await Task.Yield();
      throw new NotImplementedException();

      // return this.RedirectToAction("Index", "Books", new { q });
    }
  }
}

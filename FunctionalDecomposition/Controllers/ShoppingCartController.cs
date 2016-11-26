using System.Linq;
using System.Threading.Tasks;
using FunctionalDecomposition.DataTransferObjects;
using FunctionalDecomposition.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FunctionalDecomposition.Controllers
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
      if (!this.ModelState.IsValid)
      {
        return this.BadRequest(this.ModelState);
      }

      var model = (await this.bookService.Get(dto.Id)).First();
      await this.shoppingCartService.AddBookAsync(model);

      return this.RedirectToAction("Index", "Books", new { q });
    }
  }
}

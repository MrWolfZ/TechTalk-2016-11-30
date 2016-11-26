using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FunctionalDecomposition.DataTransferObjects;
using FunctionalDecomposition.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FunctionalDecomposition.Controllers
{
  public class BooksController : Controller
  {
    private readonly IBookService bookService;
    private readonly IMapper mapper;

    public BooksController(IBookService bookService, IMapper mapper)
    {
      this.bookService = bookService;
      this.mapper = mapper;
    }

    public async Task<IActionResult> Index(string q)
    {
      this.ViewBag.Query = q;

      var result = new BookSearchResultDto
      {
        Books = new List<BookDto>()
      };

      if (string.IsNullOrEmpty(q))
      {
        return this.View(result);
      }

      var books = await this.bookService.Search(q);
      var dtos = this.mapper.Map<ICollection<BookDto>>(books);

      result.Books = dtos.Take(16).ToList();
      return this.View(result);
    }
  }
}

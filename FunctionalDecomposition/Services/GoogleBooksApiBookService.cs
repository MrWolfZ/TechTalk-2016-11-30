using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunctionalDecomposition.Models;
using FunctionalDecomposition.Services.Interfaces;

namespace FunctionalDecomposition.Services
{
  internal class GoogleBooksApiBookService : IBookService
  {
    private static readonly ICollection<Book> Books = new List<Book>
    {
      new Book
      {
        Id = "1",
        Title = "Test Book",
        ThumbnailUrl = "no URL",
        Price = new Price
        {
          Amount = 1.44,
          CurrencyCode = "CHF"
        }
      },
      new Book
      {
        Id = "2",
        Title = "Second Book",
        Price = new Price
        {
          Amount = 5.13,
          CurrencyCode = "CHF"
        }
      }
    };

    public async Task<ICollection<Book>> Search(string searchTerm)
    {
      await Task.Yield();
      return Books;
    }

    public async Task<ICollection<Book>> Get(IEnumerable<string> ids)
    {
      await Task.Yield();
      return Books.Where(b => ids.Contains(b.Id)).ToList();
    }

    public Task<ICollection<Book>> Get(string id) => this.Get(new[] { id });
  }
}

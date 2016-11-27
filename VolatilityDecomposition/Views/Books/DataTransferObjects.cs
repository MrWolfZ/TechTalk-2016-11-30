using System.Collections.Generic;
using System.Linq;
using VolatilityDecomposition.External.GoogleBooks;

namespace VolatilityDecomposition.Views.Books
{
  public static class Dto
  {
    public sealed class BookSearchResult
    {
      public static BookSearchResult Empty = new BookSearchResult(new List<ListItem>());

      public BookSearchResult(ICollection<ListItem> books)
      {
        this.Books = books;
      }

      public ICollection<ListItem> Books { get; }

      public static BookSearchResult CreateFrom(IEnumerable<Book> books) =>
        new BookSearchResult(books.Select(ListItem.CreateFrom).ToList());

      public sealed class ListItem
      {
        public ListItem(string id, string title, string thumbnailUrl, Price priceDescriptor)
        {
          this.Id = id;
          this.Title = title;
          this.ThumbnailUrl = thumbnailUrl;
          this.PriceDescriptor = priceDescriptor;
        }

        public string Id { get; }
        public string Title { get; }
        public string ThumbnailUrl { get; }
        public Price PriceDescriptor { get; }

        public static ListItem CreateFrom(Book b) =>
          new ListItem(b.Id, b.Title, b.ThumbnailUrl, Price.CreateFrom(b.Price));

        public sealed class Price
        {
          public Price(double amount, string currencyCode)
          {
            this.Amount = amount;
            this.CurrencyCode = currencyCode;
          }

          public double Amount { get; }
          public string CurrencyCode { get; }

          public static Price CreateFrom(External.GoogleBooks.Price p) =>
            new Price(p.Amount, p.CurrencyCode);
        }
      }
    }
  }
}

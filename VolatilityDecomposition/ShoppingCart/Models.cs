using System.Collections.Generic;
using VolatilityDecomposition.DataAccess;

namespace VolatilityDecomposition.ShoppingCart
{
  public class ShoppingCart : IIdentifiable
  {
    public ShoppingCart(long id, IReadOnlyCollection<Book> books, Price totalPrice)
    {
      this.Id = id;
      this.Books = books;
      this.TotalPrice = totalPrice;
    }

    public long Id { get; }
    public IReadOnlyCollection<Book> Books { get; }
    public Price TotalPrice { get; }

    public static ShoppingCart CreateEmpty(long id) => new ShoppingCart(id, new List<Book>(), new Price(0, "CHF"));

    public ShoppingCart With(IReadOnlyCollection<Book> books = null, Price totalPrice = null) =>
      new ShoppingCart(this.Id, books ?? this.Books, totalPrice ?? this.TotalPrice);

    public sealed class Book
    {
      public Book(string id, string title, string thumbnailUrl, Price price)
      {
        this.Id = id;
        this.Title = title;
        this.ThumbnailUrl = thumbnailUrl;
        this.Price = price;
      }

      public string Id { get; }
      public string Title { get; }
      public string ThumbnailUrl { get; }
      public Price Price { get; }

      public static Book CreateFrom(External.GoogleBooks.Book b) =>
        new Book(b.Id, b.Title, b.ThumbnailUrl, Price.CreateFrom(b.Price));
    }

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

      public Price With(double? amount = null, string currencyCode = null) =>
        new Price(amount ?? this.Amount, currencyCode ?? this.CurrencyCode);
    }
  }
}

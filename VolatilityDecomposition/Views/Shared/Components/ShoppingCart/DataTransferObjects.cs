using System.Collections.Generic;
using System.Linq;

namespace VolatilityDecomposition.Views.Shared.Components.ShoppingCart
{
  public static class Dto
  {
    public sealed class ShoppingCart
    {
      public ShoppingCart(ICollection<Item> books, Price totalPrice)
      {
        this.Books = books;
        this.TotalPrice = totalPrice;
      }

      public ICollection<Item> Books { get; }
      public Price TotalPrice { get; }

      public static ShoppingCart CreateFrom(VolatilityDecomposition.ShoppingCart.ShoppingCart c) =>
        new ShoppingCart(c.Books.Select(Item.CreateFrom).ToList(), Price.CreateFrom(c.TotalPrice));

      public sealed class Item
      {
        public Item(string id, string title, Price price)
        {
          this.Id = id;
          this.Title = title;
          this.Price = price;
        }

        public string Id { get; }
        public string Title { get; }
        public Price Price { get; }

        public static Item CreateFrom(VolatilityDecomposition.ShoppingCart.ShoppingCart.Book b) =>
          new Item(b.Id, b.Title, Price.CreateFrom(b.Price));
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

        public static Price CreateFrom(VolatilityDecomposition.ShoppingCart.ShoppingCart.Price p) =>
          new Price(p.Amount, p.CurrencyCode);
      }
    }
  }
}

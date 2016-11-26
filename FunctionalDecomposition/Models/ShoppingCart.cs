using System.Collections.Generic;
using FunctionalDecomposition.DataAccess.Interfaces;

namespace FunctionalDecomposition.Models
{
  public class ShoppingCart : IIdentifiable
  {
    public long Id { get; set; }
    public ICollection<Book> Books { get; set; }
    public Price TotalPrice { get; set; }
  }
}

using System.Collections.Generic;
using VolatilityDecomposition.DataAccess.Interfaces;

namespace VolatilityDecomposition.Models
{
  public class ShoppingCart : IIdentifiable
  {
    public long Id { get; set; }
    public ICollection<Book> Books { get; set; }
    public Price TotalPrice { get; set; }
  }
}

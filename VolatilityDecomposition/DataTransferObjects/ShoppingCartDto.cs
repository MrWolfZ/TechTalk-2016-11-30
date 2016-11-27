using System.Collections.Generic;

namespace VolatilityDecomposition.DataTransferObjects
{
  public sealed class ShoppingCartDto
  {
    public ICollection<BookDto> Books { get; set; }
    public PriceDto TotalPrice { get; set; }
  }
}
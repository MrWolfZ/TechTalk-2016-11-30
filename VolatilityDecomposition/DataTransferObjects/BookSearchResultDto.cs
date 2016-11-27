using System.Collections.Generic;

namespace VolatilityDecomposition.DataTransferObjects
{
  public sealed class BookSearchResultDto
  {
    public ICollection<BookDto> Books { get; set; }
  }
}

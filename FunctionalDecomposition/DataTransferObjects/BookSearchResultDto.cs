using System.Collections.Generic;

namespace FunctionalDecomposition.DataTransferObjects
{
  public sealed class BookSearchResultDto
  {
    public ICollection<BookDto> Books { get; set; }
  }
}

using System.Collections.Generic;

namespace VolatilityDecomposition.External.GoogleBooks.DataTransferObjects
{
  public sealed class GoogleBooksVolumeInfoDto
  {
    public string Title { get; set; }
    public ICollection<string> Authors { get; set; }
    public GoogleBooksVolumeInfoImageLinksDto ImageLinks { get; set; }
  }
}
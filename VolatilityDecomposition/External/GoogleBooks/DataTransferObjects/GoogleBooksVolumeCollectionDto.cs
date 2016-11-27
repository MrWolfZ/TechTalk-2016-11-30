using System.Collections.Generic;

namespace VolatilityDecomposition.External.GoogleBooks.DataTransferObjects
{
  public sealed class GoogleBooksVolumeCollectionDto
  {
    public ICollection<GoogleBooksVolumeDto> Items { get; set; }
  }
}
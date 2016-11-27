using System.Collections.Generic;

namespace VolatilityDecomposition.ExternalDataTransferObjects
{
  public sealed class GoogleBooksVolumeCollectionDto
  {
    public ICollection<GoogleBooksVolumeDto> Items { get; set; }
  }
}
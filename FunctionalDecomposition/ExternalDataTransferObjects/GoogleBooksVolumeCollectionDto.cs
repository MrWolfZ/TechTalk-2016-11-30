using System.Collections.Generic;

namespace FunctionalDecomposition.ExternalDataTransferObjects
{
  public sealed class GoogleBooksVolumeCollectionDto
  {
    public ICollection<GoogleBooksVolumeDto> Items { get; set; }
  }
}
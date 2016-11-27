namespace VolatilityDecomposition.External.GoogleBooks.DataTransferObjects
{
  public sealed class GoogleBooksVolumeDto
  {
    public string Id { get; set; }
    public GoogleBooksVolumeSaleInfoDto SaleInfo { get; set; }
    public GoogleBooksVolumeInfoDto VolumeInfo { get; set; }
  }
}

namespace VolatilityDecomposition.Models
{
  public sealed class Book
  {
    public string Id { get; set; }
    public string Title { get; set; }
    public string ThumbnailUrl { get; set; }
    public Price Price { get; set; }
  }
}
